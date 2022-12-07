using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShopGS.Models
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Delivery date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DeliveryDate { get; set; }
    }
}