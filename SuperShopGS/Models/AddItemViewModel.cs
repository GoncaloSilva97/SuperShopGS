using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperShopGS.Models
{
    public class AddItemViewModel
    {
        [Display(Name = "Product")]
        [Range(1,int.MaxValue, ErrorMessage ="You must select a product.")]
        public int ProductId { get; set; }


        
        [Range(0.00001, double.MaxValue, ErrorMessage = "The quantity must be a positiv number.")]
        public double Quantity { get; set; }


        public IEnumerable<SelectListItem> Product { get; set; }
    }
}
