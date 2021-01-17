using FastFix2._0.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using FastFix2._0.Areas.Identity;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;

namespace FastFix2._0.Controllers.CarOwnerGarage
{
    /// <summary>
    /// Controller for CarOwners personal area.
    /// </summary>
    public class CarOwnerGarageController : Controller
    {
        /// <summary>
        /// Returns View of CarOwners personal area.
        /// </summary>
        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public CarOwnerGarageController(FastFixDbContext context, UserManager<User> userManager)
        {
            _db = context;
            _UserManager = userManager;
        }

        public IActionResult CarOwnerGarage()
        {
            var user = _UserManager.GetUserId(User);

            var app = from a in _db.NewApplications
                       where a.UserId == user
                       select a;

            return View(app.ToList());
        }
    }
}
