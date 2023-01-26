using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DomainObjects.Interfaces
{
    public interface IProduct
    {
        decimal BuyingPrice { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        bool IsActive { get; set; }
        decimal MRP { get; set; }
        string Name { get; set; }
        string Remarks { get; set; }
        decimal SellingPrice { get; set; }
    }
}
