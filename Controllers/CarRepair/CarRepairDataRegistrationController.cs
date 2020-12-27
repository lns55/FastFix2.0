using FastFix2._0.Areas.Identity;
using FastFix2._0.Infrastructure.Interfaces;
using FastFix2._0.ViewModels.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarRepair
{
    public class CarRepairDataRegistrationController : Controller
    {

        private readonly ICarRepairData _carRepair;

        public CarRepairDataRegistrationController(ICarRepairData carRepair) => _carRepair = carRepair;

        [HttpGet]
        public IActionResult CarRepairDataRegistration(int id)
        {
            if (id is 0)
                return View(new CarRepairDataRegistrationViewModel());

            if (id < 0)
                return BadRequest();

            return View(new CarRepairDataRegistrationViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]

        public  IActionResult CarRepairDataRegistration(CarRepairDataRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var carRepairData = new CarRepairUser
            {
                CoName = model.CoName,
                CoAdress = model.CoAdress,
                CoPhoneNumber = model.CoPhoneNumber,
                CoEmail = model.CoEmail
            };

            if (model.Id == 0)
                _carRepair.Add(carRepairData);

            _carRepair.SaveChanges();

            return RedirectToAction("CarRepairWorkshop","CarRepairWorkshop");
        }
    }
}
