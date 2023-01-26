using MediatR;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationContext _context;
        public UpdateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();
            if (product == null)
            {
                return default;
            }
            else
            {
                product.Name = command.Name;
                product.Description = command.Description;
                product.MRP = command.MRP;
                product.BuyingPrice = command.BuyingPrice;
                product.IsActive = command.IsActive;
                product.Remarks = command.Remarks;
                await _context.Complete();
                return product.Id;
            }
        }
    }

}
