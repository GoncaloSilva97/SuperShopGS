using SuperShopGS.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShopGS.Data
{
    public interface IOrderRepository : IGenericRepository <Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);


    }
}
