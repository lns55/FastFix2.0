using FastFix2._0.Areas.Applications;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.ViewModels.Applications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FastFix2._0.Controllers.CarOwnerGarage.MyApplications
{
    public class MyApplicationsController : Controller
    {
        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public MyApplicationsController(FastFixDbContext context, UserManager<User> UserManager)
        {
            _db = context;
            _UserManager = UserManager;
        }

        #region Page where carowners can leave new applications for carrepairs.
        public IActionResult New() => View(new CreateApplicationViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult New(CreateApplicationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string user = _UserManager.GetUserId(User);

            string date = model.RepairFrom.ToShortDateString();

            string Date = date.ToString();

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
                _db.Add(app);
            }

            _db.SaveChanges();

            return RedirectToAction("CarOwnerGarage", "CarOwnerGarage");
        }
        #endregion

        #region Page where carowners look for applicaitons that are waiting for answers from carrepairs.
        public IActionResult Waiting()
        {
            string userId = _UserManager.GetUserId(User);

            var app = from a in _db.NewApplications
                      where userId == a.UserId
                      select a;

            return View(app.ToList());
        }
        #endregion

        #region Method to see answers for concrete applications on Waiting Page.
        public IActionResult LookAnswers(int Id)
        {
            var answers = from a in _db.AnswersForApps
                          where a.AppID == Id
                          select a;

            return View(answers.ToList());
        }
        #endregion

        #region Method to accept proper answer for applicaiton.
        public IActionResult Accept(int AppID)
        {
            var app = _db.NewApplications.Where(a => a.Id == AppID).FirstOrDefault();

            var answer = _db.AnswersForApps.Where(a => a.AppID == AppID).FirstOrDefault();

            ApplicationsInProgress inProgress = new ApplicationsInProgress
            {
                Car = app.Car,
                City = app.City,
                Description = app.Description,
                IssueTitle = app.IssueTitle,
                RepairFrom = app.RepairFrom,
                RepairTill = app.RepairTill,
                TypeOfWork = app.TypeOfWork,
                UserId = app.UserId,
                Message = answer.Message,
                Price = answer.Price,
                CarRepairId = answer.UserId
            };

            _db.ApplicationsInProgress.Add(inProgress);

            _db.NewApplications.Remove(app);

            _db.AnswersForApps.Remove(answer);

            _db.SaveChanges();

            return RedirectToAction("InProgress", "MyApplications");
        }
        #endregion

        #region Page to see applications that are in progress.
        public IActionResult InProgress()
        {
            string getUserId = _UserManager.GetUserId(User);

            var app = _db.ApplicationsInProgress.Where(a => a.UserId == getUserId);

            return View(app.ToList());
        }
        #endregion

        #region Method where carowners can see details of apps that are in progress.
        public IActionResult SeeApp(int Id)
        {
            var app = _db.ApplicationsInProgress.Where(a => a.Id == Id).FirstOrDefault();

            return View(app);
        }
        #endregion

        #region Method which invokes when carowner press finish application, but carrepair didnt finished work.
        public IActionResult FalseFinish()
        {
            return View();
        }
        #endregion

        #region Method which invokes when carowner approve of finished work(after carrepair pressed finished).
        public IActionResult Finish(int Id)
        {

            var App = _db.ApplicationsInProgress.Where(a => a.Id == Id).First();

            if (App.IsFinished == false)
            {
                return RedirectToAction("FalseFinish", "MyApplications");
            }
            if (App.IsFinished == true)
            {
                CompletedApplications completed = new CompletedApplications
                {
                    Car = App.Car,
                    City = App.City,
                    Description = App.Description,
                    IssueTitle = App.IssueTitle,
                    RepairFrom = App.RepairFrom,
                    RepairTill = App.RepairTill,
                    TypeOfWork = App.TypeOfWork,
                    UserId = App.UserId,
                    Message = App.Message,
                    Price = App.Price,
                    CarRepairId = App.CarRepairId
                };

                _db.CompletedApplications.Add(completed);

                _db.ApplicationsInProgress.Remove(App);

                _db.SaveChanges();
            }

            return View();
        }
        #endregion

        #region Page where carowner can see all completed applications.
        public IActionResult Completed()
        {
            string userId = _UserManager.GetUserId(User);

            var getApps = _db.CompletedApplications.Where(a => a.UserId == userId);

            return View(getApps.ToList());
        }
        #endregion
    }
}
