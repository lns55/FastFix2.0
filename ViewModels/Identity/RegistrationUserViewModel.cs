using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Identity
{
    public class RegistrationUserViewModel
    {
        [Required, MaxLength(20)]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Email Confirmation")]
        [DataType(DataType.EmailAddress)]
        [Compare(nameof(Email))]
        public string EmailConfirm { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Password Confirmation")]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
