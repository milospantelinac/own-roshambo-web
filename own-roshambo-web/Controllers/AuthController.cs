using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OwnRoshamboWeb.Extensions;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.ViewModels;
using System;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginUser = await _authService.Login(loginModel.Email, loginModel.Password);
                    if (loginUser != null)
                    {
                        HttpContext.Response.Cookies.Append(RegisterJwtAuthIServiceCollectionExtension.AuthCookieName, loginUser.Token, new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Strict });
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (ApplicationException ex)
                {
                    ModelState.AddModelError("ErrorMsg", ex.Message);
                    return View(loginModel);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ErrorMsg", "Server Error");
                    return View(loginModel);
                }
            }
            return View(loginModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(RegisterJwtAuthIServiceCollectionExtension.AuthCookieName);
            return RedirectToAction("Login", "Auth");
        }
    }
}
