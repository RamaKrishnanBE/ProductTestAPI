using Microsoft.EntityFrameworkCore;
using ProductTest.DataAccess.EFCore.Interfaces;
using ProductTest.DomainObjects.Models;

namespace ProductTest.DataAccess.EFCore
{


    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public async  Task<int> Complete()
        {
            return await base.SaveChangesAsync();
        }
    }
}