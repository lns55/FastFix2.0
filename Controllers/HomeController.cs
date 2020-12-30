using FastFix2._0.Areas.Identity;
using FastFix2._0.Infrastructure.Services;
using FastFix2._0.Models;
using FastFix2._0.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public HomeController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }


        /// <summary>
        /// Response for Login and it is also entry method(Index).
        /// </summary>
        #region LOGIN

        public IActionResult Index() => View();

        /// <summary>
        /// Login method.
        /// </summary>
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
                if (User.IsInRole("CarRepair"))
                {
                    return RedirectToAction("CarRepairWorkshop", "CarRepairWorkshop");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Wrong User Name or Password");

            return View(model);
        }

        #endregion

        #region REGISTRATION

        public IActionResult Registration() => View(new RegistrationUserViewModel());
        /// <summary>
        /// If registration result succeeded sending email confirmation letter to the user and adding to certain role.
        /// </summary>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                IsCarRepair = model.IsCarRepair
            };
            
            var registration_result = await _UserManager.CreateAsync(user, model.Password);
            
            if (registration_result.Succeeded)
            {
                var Code = await _UserManager.GenerateEmailConfirmationTokenAsync(user);

                var CallbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Home",
                    new { userId = user.Id, code = Code, isCarRepair = user.IsCarRepair},
                    protocol: HttpContext.Request.Scheme);

                EmailService emailService = new EmailService();

                await emailService.SendEmailAsync(model.Email, "Confirm your account",
                    $"Confirm registration following this <a href='{CallbackUrl}'>link</a>");

                await _UserManager.AddToRoleAsync(user, "CarRepair");

                return RedirectToAction("EmailVerification","Home");
            }

            foreach (var error in registration_result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        //Email Confirmation Method Starts Here
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code, bool IsCarRepair)
        {

            if(userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _UserManager.FindByIdAsync(userId);

            if(user == null)
            {
                return View("Error");
            }

            var result = await _UserManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                if (IsCarRepair == true)
                {
                    return RedirectToAction("CarRepairDataRegistration", "CarRepairDataRegistration");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View("Error");
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

        #region EMAIL VERIFICATION

        public IActionResult EmailVerification() => View();

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
