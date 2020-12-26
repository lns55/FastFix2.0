using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Identity
{
    public class CarRepairDataRegistrationViewModel
    {
        [Required]
        [Display(Name ="Company Name")]
        public string CoName { get; set; }

        [Required]
        [Display(Name ="Company Adress")]
        public string CoAdress { get; set; }

        [Required, MaxLength(15)]
        [Display(Name ="Company Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string CoPhoneNumber { get; set; }

        [Required]
        [Display(Name ="Company Email Adress")]
        [DataType(DataType.EmailAddress)]
        public string CoEmail { get; set; }
    }
}
