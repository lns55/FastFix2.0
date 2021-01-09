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

        [Required(ErrorMessage = "Issue title is required")]
        [StringLength(100, ErrorMessage = "Title must contain maximum 100 characters")]
        public string IssueTitle { get; set; }

        [Required(ErrorMessage = "You must choose car to repair")]
        [Display(Name = "Car Model")]
        public string Car { get; set; }

        [Required(ErrorMessage = "Choose the date of repair")]
        [DataType(DataType.DateTime, ErrorMessage = "You must choose date of repair")]
        [DisplayFormat(DataFormatString = "0:dd'/'MM'/'yyyy", ConvertEmptyStringToNull = true, NullDisplayText = "You must choose date of repair")]
        public DateTime RepairFrom { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:dd'/'MM'/'yyyy'", ConvertEmptyStringToNull = false)]
        public DateTime RepairTill { get; set; }

        [Required(ErrorMessage = "You must choose city where you want to repair your car")]
        public string City { get; set; }

        public string TypeOfWork { get; set; }

        [Required(ErrorMessage = "Describe your issue")]
        public string Description { get; set; }
    }
}
