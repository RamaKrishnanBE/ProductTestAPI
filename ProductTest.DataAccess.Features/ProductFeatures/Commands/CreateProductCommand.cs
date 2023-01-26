using MediatR;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MRP { get; set; }
        public decimal BuyingPrice { get; set; }
        public string Remarks { get; set; }
    }
}
