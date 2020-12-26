using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Identity
{
    public class CarRepairDataRegistrationViewModel
    {
        //Co is for Company

        [Required]
        [Display(Name ="Company Name")]
        public string CoName { get; set; }

        [Required]
        [MaxLength(30)]
        public string CoRegNumber { get; set; }

        [Required]
        public string CoAdress { get; set; }

        [Required, MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string CoPhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CoEmail { get; set; }

    }
}
