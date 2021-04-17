using Microsoft.AspNetCore.Mvc;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.ViewModels;
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
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            var user = await _authService.Login(loginModel.Email, loginModel.Password);
            return Ok();
        }
    }
}
