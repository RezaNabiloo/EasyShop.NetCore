using BSG.EasyShop.WebUI.MVC.Contracts;
using BSG.EasyShop.WebUI.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSG.EasyShop.WebUI.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public UserController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }


        public async Task<ActionResult> Login(LoginVM login, string returnUrl)
        {

            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticateService.Authenticate(login.Email, login.Password);

            if (isLoggedIn)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "failed. tray again.");
            return View(login);
        }

        [HttpPost]
        public async Task<ActionResult> Logout() 
        {
            await _authenticateService.Logout();
            return LocalRedirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {

                return View(register);
            }
            var isCredit = await _authenticateService.Register(register);
            if (isCredit)
            {
                return LocalRedirect("/");
            }
            ModelState.AddModelError("", "failed.");
            return View(register);
        }


    }
}
