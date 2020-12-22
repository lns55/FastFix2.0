using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }

    }
}
