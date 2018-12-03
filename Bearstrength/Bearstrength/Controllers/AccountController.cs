using Bearstrength.Models;
using Bearstrength.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bearstrength.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<BearstrengthUser> _signInManager;
        private readonly UserManager<BearstrengthUser> _userManager;

        public AccountController(SignInManager<BearstrengthUser> signInManager, UserManager<BearstrengthUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Activity");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    model.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Activity");
                    }
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }

        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Activity");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new BearstrengthUser
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(
                        model.Username,
                        model.Password,
                        false, false);
                    if (signInResult.Succeeded)
                    {
                        if (Request.Query.Keys.Contains("ReturnUrl"))
                        {
                            return Redirect(Request.Query["ReturnUrl"]);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Activity");
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}