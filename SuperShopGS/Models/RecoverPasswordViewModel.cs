using System.ComponentModel.DataAnnotations;

namespace SuperShopGS.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}