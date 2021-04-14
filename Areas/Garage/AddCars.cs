using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Areas.Garage
{
    public class AddCars
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CarModel { get; set; }
        public string Engine { get; set; }
        public int Year { get; set; }
        public string CarPlate { get; set; }
        public string VinCode { get; set; }
        public bool IsVisible { get; set; }
    }
}
