using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.Infrastructure.Interfaces;
using FastFix2._0.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarRepair
{
    /// <summary>
    /// Responsibility of this controller is validating data from second step of CarRepairShop registration and add this data to database.
    /// </summary>
    public class CarRepairDataRegistrationController : Controller
    {

        private readonly ICarRepairData _carRepair;
        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;

        public CarRepairDataRegistrationController(ICarRepairData carRepair, FastFixDbContext context,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _carRepair = carRepair;
            _db = context;
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        /// <summary>
        /// Returns data from view.
        /// </summary>
        /// <param name="id">Stands for CarRepairShops data.</param>
        [HttpGet]
        public IActionResult CarRepairDataRegistration(int id)
        {
            if (id is 0)
                return View(new CarRepairDataRegistrationViewModel());

            if (id < 0)
                return BadRequest();

            return View(new CarRepairDataRegistrationViewModel());
        }
        /// <summary>
        /// Adding CarRepair data to database.
        /// </summary>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CarRepairDataRegistration(CarRepairDataRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = _UserManager.GetUserId(User);

            var carRepairData = new CarRepairUser
            {
                CoName = model.CoName,
                CoAdress = model.CoAdress,
                CoPhoneNumber = model.CoPhoneNumber,
                CoEmail = model.CoEmail,
                TypeOfWork = model.TypeOfWork,
                UserId = userId
            };

            if (model.Id == 0)
                _carRepair.Add(carRepairData);

            _carRepair.SaveChanges();

            return RedirectToAction("CarRepairWorkshop", "CarRepairWorkshop");
        }
    }
}
