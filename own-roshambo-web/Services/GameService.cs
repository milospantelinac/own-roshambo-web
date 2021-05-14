using OwnRoshamboWeb.Interfaces.Hubs;
using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.ViewModels;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Services
{
    public class GameService : IGameService
    {
        private readonly IGameHub _gameHub;
        private readonly IGameRepository _gameRepository;
        public GameService(IGameHub gameHub, IGameRepository gameRepository)
        {
            _gameHub = gameHub;
            _gameRepository = gameRepository;
        }
 
        public async Task CreateGameRoom(CreateGameViewModel model, UserModel user)
        {
            await _gameHub.CreateGameRoom(model, user);
        }

        public async Task JoinGameRoom(JoinGameViewModel model, UserModel user)
        {
            await _gameHub.JoinGameRoom(model, user);
        }

        public async Task<bool> CheckRoomConnection(int roomId, string connectionId, UserModel user)
        {
            return await _gameRepository.CheckRoomConnection(roomId, connectionId, user);
        }
    }
}
