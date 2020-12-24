using FastFix2._0.Areas.Identity;
using FastFix2._0.Models;
using FastFix2._0.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers
{
    public class HomeController : Controller
    {

        #region LOGIN

        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;

        public HomeController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }

        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var login_result = await _SignInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                false);

            if (login_result.Succeeded)
            {
                if (Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Wrong User Name or Password");

            return View(model);
        }

        #endregion

        #region REGISTRATION

        public IActionResult Register() => View(new RegistartionUserViewModel());

        #endregion

        #region ErrorHandler

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion 
    }
}
