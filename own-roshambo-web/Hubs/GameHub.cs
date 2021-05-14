using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OwnRoshamboWeb.Interfaces.Hubs;
using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Game;
using OwnRoshamboWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Hubs
{
    [Authorize]
    public class GameHub : Hub, IGameHub
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<GameHub> _hubContext;
        private readonly IGameRepository _gameRepository;

        public GameHub(IServiceProvider serviceProvider, IHubContext<GameHub> hubContext, IGameRepository gameRepository)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
            _gameRepository = gameRepository;
        }
        public override async Task OnConnectedAsync()
        {
            var rooms = await GetAllGameRooms();
            if (rooms != null)
            {
                await _hubContext.Clients.Client(Context.ConnectionId).SendAsync("ListAvaibleRooms", Context.ConnectionId, rooms);
            }
            else
            {
                await _hubContext.Clients.Client(Context.ConnectionId).SendAsync("ListAvaibleRooms", Context.ConnectionId);
            }

            await base.OnConnectedAsync();
        } 

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task<IEnumerable<GameRoomModel>> GetAllGameRooms()
        {
            return await _gameRepository.GetAllGameRooms();
        }

        public async Task CreateGameRoom(CreateGameViewModel model, UserModel user)
        {
            var roomId = await _gameRepository.CreateGameRoom(model.RoomName);
            await _hubContext.Clients.All.SendAsync("JoinInRoom", model.ConnectionId, roomId);
        }

        public async Task JoinGameRoom(JoinGameViewModel model, UserModel user)
        {
            await _gameRepository.AddConnection(user.Id, model.ConnectionId, model.RoomId);
            await _hubContext.Clients.All.SendAsync("InGame", model.ConnectionId, model.RoomId);
        }
    }
}
