using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage.Garage
{
    public class MyGarageController : Controller
    {
        public IActionResult MyCars()
        {
            return View();
        }

        public IActionResult AddCar()
        {
            return View();
        }
    }
}
