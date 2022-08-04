using Microsoft.EntityFrameworkCore;
using SuperShopGS.Data.Entities;
using System.Linq;

namespace SuperShopGS.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public readonly DataContext _context;


        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable GetAllWithUsers()
        {
            return _context.Products.Include(p => p.User);
        }
       
    }
}
