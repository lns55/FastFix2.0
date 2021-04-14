using FastFix2._0.Areas.Garage;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.ViewModels.Garage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage.Garage
{
    public class MyGarageController : Controller
    {
        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public MyGarageController(FastFixDbContext context, UserManager<User> UserManager)
        {
            _db = context;
            _UserManager = UserManager;
        }

        public IActionResult AddCar() => View(new AddCarViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCar(AddCarViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _UserManager.GetUserId(User);

            var car = new AddCars
            {
                Id = model.Id,
                UserId = user,
                CarModel = model.CarModel,
                Engine = model.Engine,
                Year = model.Year,
                CarPlate = model.CarPlate,
                VinCode = model.VinCode,
                IsVisible = model.IsVisible
            };

            if (model.Id == 0)
            {
                _db.UsersCars.Add(car);
            }

            _db.SaveChanges();

            return RedirectToAction("MyCars","MyGarage");
        }

        public IActionResult MyCars()
        {
            return View();
        }
    }
}
