using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ITokenHelper _tokenHelper;

        public GameController(IGameService gameService, ITokenHelper tokenHelper)
        {
            _gameService = gameService;
            _tokenHelper = tokenHelper;
        }

        public IActionResult Index(int roomId, string connectionId)
        {
            var user = _tokenHelper.GetUserFromClaims(User.Claims);
            var result = _gameService.CheckRoomConnection(roomId, connectionId, user);
            if (result == null)
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [Route("{controller}/createroom")]
        public async Task CreateGameRoom([FromBody] CreateGameViewModel model)
        {
            var user = _tokenHelper.GetUserFromClaims(User.Claims);
            await _gameService.CreateGameRoom(model, user);
        }

        [HttpPost]
        [Route("{controller}/joinroom")]
        public async Task JoinGameRoom([FromBody] JoinGameViewModel model)
        {
            var user = _tokenHelper.GetUserFromClaims(User.Claims);
            await _gameService.JoinGameRoom(model, user);
        }
    }
}
