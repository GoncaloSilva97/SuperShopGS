using SuperShopGS.Data.Entities;
using SuperShopGS.Models;
using System;

namespace SuperShopGS.Helperes
{
    public interface IConverterHelper
    {
        Product ToProduct(ProductViewModel model, Guid imagId, bool isNew);////////////////////////////////////////////////

        ProductViewModel ToProductViewModel(Product product);

    }
}
