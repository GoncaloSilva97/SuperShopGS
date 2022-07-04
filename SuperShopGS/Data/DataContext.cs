using Microsoft.EntityFrameworkCore;
using SuperShopGS.Data.Entities;

namespace SuperShopGS.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
