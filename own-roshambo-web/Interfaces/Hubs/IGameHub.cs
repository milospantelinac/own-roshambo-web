using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Game;
using OwnRoshamboWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Hubs
{
    public interface IGameHub
    {
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception exception);
        Task<IEnumerable<GameRoomModel>> GetAllGameRooms();
        Task CreateGameRoom(CreateGameViewModel model, UserModel user);
        Task JoinGameRoom(JoinGameViewModel model, UserModel user);
    }
}
