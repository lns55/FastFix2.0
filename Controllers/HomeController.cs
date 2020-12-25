using FastFix2._0.Areas.Identity;
using FastFix2._0.Models;
using FastFix2._0.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IEmailSender _sender;

        public HomeController(UserManager<User> UserManager, SignInManager<User> SignInManager, IEmailSender sender)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _sender = sender;
        }
        //Login method is also ENTER method in app(Index). App is starting from this method.
        #region LOGIN

        public IActionResult Index(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
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

        public IActionResult Registration() => View(new RegistrationUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                UserName = model.UserName
            };

            var registration_result = await _UserManager.CreateAsync(user, model.Password);
            if(registration_result.Succeeded)
            {
                await _SignInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in registration_result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        //Email Confirmation Method Starts Here
        [AllowAnonymous]
        public class RegisterConfirmationModel : PageModel
        {
            
        }

        #endregion

        #region LOGOUT

        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region PASSWORD RECOVERY

        public IActionResult ForgotPassword() => View();

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
