using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameRoomModel>> GetAllGameRooms();
        Task<int> CreateGameRoom(string roomName);
        Task AddConnection(int userId, string connectionId, int roomId);
        Task<bool> CheckRoomConnection(int roomId, string connectionId, UserModel user);
    }
}
