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
        public string Car { get; set; }

        public int RepairFrom { get; set; }

        public int RepairTill { get; set; }

        public string City { get; set; }

        public string TypeOfWork { get; set; }

        [Required(ErrorMessage = "You need to describe your problem")]
        [RegularExpression(@"([A-Z][a-z])", ErrorMessage = "You must describe your problem with lattin letters.")]
        public string Description { get; set; }
    }
}
