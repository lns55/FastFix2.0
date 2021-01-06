using FastFix2._0.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using FastFix2._0.Areas.Identity;
using System.Linq;
using System.Collections.Generic;
using System;

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
        public CarOwnerGarageController(FastFixDbContext context) => _db = context;

        public IActionResult CarOwnerGarage()
        {
            var applications = _db.NewApplications.ToList();

            return View(applications);
        }
    }
}
