using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DataAccess.Features.ProductFeatures.Queries;
using ProductTest.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationContext _context;
        public GetProductByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
