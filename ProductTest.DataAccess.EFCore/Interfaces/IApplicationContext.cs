using Microsoft.EntityFrameworkCore;
using ProductTest.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.DataAccess.EFCore.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> Complete();
    }
}
