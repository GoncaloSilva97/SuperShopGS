﻿using System;
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
        public Guid ImageId { get; set; }//////////////////////////////////////////////////////////////////////
       

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }






        public User User { get; set; }







        ////////////////////////////////////////////////////////////////////////////
<<<<<<< HEAD
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://supershopgs.azurewebsites.net/image/noimage.png"
            : $"https://supershopgs.blob.core.windows.net/products/{ImageId}";
        
=======
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }

                return $"https://supershopgs.azurewebsites.net{ImageUrl.Substring(1)}";
            }
        }
>>>>>>> ff399bacf84adf4f6dccc770e92193b0295d32ae

        /////////////////////////////////////////////////////////////////////////
    }
}
