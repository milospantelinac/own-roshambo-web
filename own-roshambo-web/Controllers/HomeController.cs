using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Models;
using System.Diagnostics;

namespace OwnRoshamboWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITokenHelper _tokenHelper;

        public HomeController(ILogger<HomeController> logger, ITokenHelper tokenHelper)
        {
            _logger = logger;
            _tokenHelper = tokenHelper;
        }

        public IActionResult Index()
        {
            return View(_tokenHelper.GetUserFromClaims(User.Claims));
        }

        public IActionResult Room()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
