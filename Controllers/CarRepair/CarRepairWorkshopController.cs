using FastFix2._0.Areas.Applications;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.ViewModels.Applications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers
{
    /// <summary>
    /// After car repair company fill out form with their data, they will get into this controller(their Private Cabinet).
    /// </summary>

    public class CarRepairWorkshopController : Controller
    {

        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public CarRepairWorkshopController(FastFixDbContext context, UserManager<User> userManager)
        {
            _db = context;
            _UserManager = userManager;
        }

        public IActionResult CarRepairWorkshop()
        {
            var user = _UserManager.GetUserId(User);

            var findUser = _db.Users.Find(user);

            var userCity = findUser.City;

            var app = from a in _db.NewApplications
                      where a.City == userCity
                      select a;

            return View(app.ToList());
        }
        #region Displaying new applications for CarRepair.
        public IActionResult New()
        {
            var getUserId = _UserManager.GetUserId(User);

            var getUser = _db.Users.Where(u => u.IsCarRepair == true && u.Id == getUserId).FirstOrDefault();

            var apps = _db.NewApplications.Where(a => a.City == getUser.City);

            return View(apps.ToList());
        }
        #endregion

        #region Page to leave answer for new applications.
        public IActionResult AnswerPage() => View(new AnswerForAppViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AnswerPage(AnswerForAppViewModel model, int Id)
        {
            var userId = _UserManager.GetUserId(User);
            
            var answer = new AnswersForApps
            {
                AppID = Id,
                Message = model.Message,
                Price = model.Price,
                UserId = userId
            };

            _db.Add(answer);
            _db.SaveChanges();

            return RedirectToAction("Waiting", "CarRepairWorkshop");
        }
        #endregion

        #region Page where CarRepairs can see apps for which they answered.
        public IActionResult Waiting()
        {
            var getUserId = _UserManager.GetUserId(User);

            var getUserAnswer = _db.AnswersForApps.Where(a => a.UserId == getUserId).Select(a => a.AppID);

            var getApps = _db.NewApplications.Where(a => a.Id.ToString() == getUserAnswer.ToString());

            return View(getApps.ToList());
        }
        #endregion

        #region Page to see details of answers for new apps.
        public IActionResult LookAnswer(int Id)
        {
            var getUserId = _UserManager.GetUserId(User);

            var answer = _db.AnswersForApps.Where(a => a.AppID == Id && a.UserId == getUserId).First();

            return View(answer);
        }
        #endregion

        #region Page where displays apps which are in work(they appear on this page after car owner accept answer of car repair).
        public IActionResult InProgress()
        {
            var getUserId = _UserManager.GetUserId(User);

            var checkAppStatus = _db.ApplicationsInProgress.Where(s => s.CarRepairId == getUserId);

            if(checkAppStatus != null)
            {
                return View(checkAppStatus.ToList());
            }

            return View();
        }
        #endregion

        #region Page where carrepair can see details of apps which are in progress.
        public IActionResult SeeApp(int Id)
        {
            var app = _db.ApplicationsInProgress.Where(a => a.Id == Id).FirstOrDefault();

            return View(app);
        }
        #endregion

        #region Method that invokes when carrepair finished work and press button Finished App. After that carrepair wait for approvement from carowner.
        public IActionResult Finished(int Id)
        {
            var getApp = _db.ApplicationsInProgress.Where(c => c.Id == Id).First();

            if(getApp != null)
            {
                getApp.IsFinished = true;

                _db.SaveChanges();
            }

            return View();
        }
        #endregion

        #region Page where displays all completed applications.
        public IActionResult Completed()
        {
            var userId = _UserManager.GetUserId(User);

            var getApps = _db.CompletedApplications.Where(a => a.CarRepairId == userId);

            return View(getApps.ToList());
        }
        #endregion
    }
}
