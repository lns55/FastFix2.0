using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Applications
{
    public class AnswerForAppViewModel : CreateApplicationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public new int Id { get; set; }

        [StringLength(1000, ErrorMessage = "Answer must contain maximum 1000 characters")]
        public string Message { get; set; }

        public int Price { get; set; }

        public int AppID { get; set; }
    }
}
