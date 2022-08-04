using Microsoft.EntityFrameworkCore;
using SuperShopGS.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShopGS.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUsers();

    }
}
