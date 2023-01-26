using MediatR;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using ProductTest.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Name = command.Name;
            product.Description = command.Description;
            product.MRP = command.MRP;
            product.BuyingPrice = command.BuyingPrice;
            product.SellingPrice = ((Convert.ToDecimal(10) / Convert.ToDecimal(100)) * command.BuyingPrice);
            product.IsActive = true;
            product.Remarks = command.Remarks;
            await _context.Products.AddAsync(product);
            await _context.Complete();
            return product.Id;
        }
    }

}
