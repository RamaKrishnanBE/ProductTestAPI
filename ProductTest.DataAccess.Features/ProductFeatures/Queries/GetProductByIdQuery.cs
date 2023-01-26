using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
