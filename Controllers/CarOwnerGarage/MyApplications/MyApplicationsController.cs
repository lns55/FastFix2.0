using FastFix2._0.Data;
using FastFix2._0.ViewModels.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage.MyApplications
{
    public class MyApplicationsController : Controller
    {
        /// <summary>
        /// This method is resopnsible for creating new applications from CarOwners to CarReparis.
        /// </summary>
        public IActionResult New() => View(new CreateApplicationViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(CreateApplicationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var app = new NewApplications
            {
                Id = model.Id,
                IssueTitle = model.IssueTitle,
                Car = model.Car,
                RepairFrom = model.RepairFrom,
                RepairTill = model.RepairTill,
                City = model.City,
                TypeOfWork = model.TypeOfWork,
                Description = model.Description
            };

            if (model.Id == 0) 
                
        }


        public IActionResult Active() => View();
        public IActionResult Waiting() => View();
        public IActionResult Completed() => View();
    }
}
