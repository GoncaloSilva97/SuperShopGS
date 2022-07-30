using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShopGS.Data.Entities
{
    public class Product : IEntity
    {




        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage ="The filde {0} can contain {1} Characteres length.")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }






        public User User { get; set; }
    }
}
