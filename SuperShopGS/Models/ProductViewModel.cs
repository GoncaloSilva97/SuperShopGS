using Microsoft.AspNetCore.Http;
using SuperShopGS.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace SuperShopGS.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
