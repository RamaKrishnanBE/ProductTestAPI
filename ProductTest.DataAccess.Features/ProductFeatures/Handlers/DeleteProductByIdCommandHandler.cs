using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DataAccess.Features.ProductFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Handlers
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly IApplicationContext _context;
        public DeleteProductByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (product == null)
            {
                return default;
            }
            _context.Products.Remove(product);
            await _context.Complete();
            return product.Id;
        }
    }

}
