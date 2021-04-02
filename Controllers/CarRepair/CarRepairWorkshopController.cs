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


        public IActionResult AnswerPage() => View(new AnswerForAppViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AnswerPage(AnswerForAppViewModel model, int Id)
        {
            var answer = new AnswersForApps
            {
                AppID = Id,
                Message = model.Message,
                Price = model.Price
            };

            _db.Add(answer);
            _db.SaveChanges();

            return RedirectToAction("CarRepairWorkshop", "CarRepairWorkshop");
        }

        public IActionResult Waiting() => View();
    }
}
