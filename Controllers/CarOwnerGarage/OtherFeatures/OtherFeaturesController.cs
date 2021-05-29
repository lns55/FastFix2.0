using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FastFix2._0.Controllers.CarOwnerGarage.OtherFeatures
{
    public class OtherFeaturesController : Controller
    {
        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public OtherFeaturesController(FastFixDbContext context, UserManager<User> UserManager)
        {
            _db = context;
            _UserManager = UserManager;
        }

        public IActionResult AccountSettings()
        {

            return View();
        }
    }
}
