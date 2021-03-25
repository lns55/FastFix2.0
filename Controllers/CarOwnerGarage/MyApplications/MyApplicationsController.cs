using FastFix2._0.Areas.Applications;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.ViewModels.Applications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FastFix2._0.Controllers.CarOwnerGarage.MyApplications
{
    public class MyApplicationsController : Controller
    {
        private readonly FastFixDbContext db;
        private readonly UserManager<User> userManager;

        public MyApplicationsController(FastFixDbContext context, UserManager<User> UserManager)
        {
            db = context;
            userManager = UserManager;
        }

        /// <summary>
        /// This method is resopnsible for creating new applications from CarOwners to CarReparis.
        /// </summary>
        public IActionResult New() => View(new CreateApplicationViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult New(CreateApplicationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = userManager.GetUserId(User);

            var date = model.RepairFrom.ToShortDateString();

            var Date = date.ToString();

            var app = new NewApplications
            {
                Id = model.Id,
                IssueTitle = model.IssueTitle,
                Car = model.Car,
                RepairFrom = Date,
                RepairTill = model.RepairTill,
                City = model.City,
                TypeOfWork = model.TypeOfWork,
                Description = model.Description,
                UserId = user
            };

            if (model.Id == 0)
            {
                db.Add(app);
            }

            db.SaveChanges();

            return RedirectToAction("CarOwnerGarage", "CarOwnerGarage");
        }

        public IActionResult Active() => View();
        public IActionResult Waiting() => View();
        public IActionResult Completed() => View();
    }
}
