using FastFix2._0.ViewModels.Garage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage.Garage
{
    public class MyGarageController : Controller
    {
        public IActionResult AddCar() => View(new AddCarViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCar(AddCarViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);



            return RedirectToAction("MyCars");
        }

        public IActionResult MyCars()
        {
            return View();
        }
    }
}
