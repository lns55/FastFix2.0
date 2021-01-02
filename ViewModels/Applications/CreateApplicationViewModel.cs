using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.ViewModels.Applications
{
    public class CreateApplicationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Invalid value")]
        public string IssueTitle { get; set; }

        [Display(Name = "Car Model")]
        [Required(ErrorMessage = "Car model is required")]
        [RegularExpression(@"a-z", ErrorMessage = "Car model must be written with lattin letters.")]
        public string Car { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:dd'/'MM'/'yyyy")]
        [Required(ErrorMessage = "Select date when you are ready to start repearing.")]
        public int RepairFrom { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:dd'/'MM'/'yyyy")]
        [Required(ErrorMessage = "Select date when the work must be done")]
        public int RepairTill { get; set; }

        [Required(ErrorMessage = "You need to choose a city")]
        public string City { get; set; }

        public string TypeOfWork { get; set; }

        [Required(ErrorMessage = "You need to describe your problem")]
        [StringLength(1000, MinimumLength = 8, ErrorMessage = "Minimum length 8 letters")]
        [RegularExpression(@"([A-Z][a-z])", ErrorMessage = "You must describe your problem with lattin letters.")]
        public string Description { get; set; }
    }
}
