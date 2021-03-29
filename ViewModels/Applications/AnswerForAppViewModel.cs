using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.ViewModels.Applications
{
    public class AnswerForAppViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(1000, ErrorMessage = "Answer must contain maximum 1000 characters")]
        public string Message { get; set; }

        public int Price { get; set; }

        public int AppID { get; set; }
    }
}
