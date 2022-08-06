using SuperShopGS.Data.Entities;
using SuperShopGS.Models;

namespace SuperShopGS.Helperes
{
    public interface IConverterHelper
    {
        Product ToProduct(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(Product product);

    }
}
