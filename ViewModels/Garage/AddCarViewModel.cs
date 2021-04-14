using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.ViewModels.Garage
{
    public class AddCarViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to fill this field")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "You need to fill this field")]
        public string Engine { get; set; }

        [Required(ErrorMessage = "You need to fill this field")]
        public int Year { get; set; }

        [StringLength(6, ErrorMessage = "Fill this field like shown in example: 123 ABC")]
        public string CarPlate { get; set; }
        public string VinCode { get; set; }
        public bool IsVisible { get; set; }
    }
}
