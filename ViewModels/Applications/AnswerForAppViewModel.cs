using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.ViewModels.Applications
{
    public class AnswerForAppViewModel
    {
        [Required(ErrorMessage = "You need to write your answer before sending it")]
        [StringLength(1000, ErrorMessage = "Answer must contain maximum 1000 characters")]
        public string Message { get; set; }

        [Required(ErrorMessage = "You must write approximate price")]
        public int Price { get; set; }
    }
}
