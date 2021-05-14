using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.ViewModels;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Services
{
    public interface IGameService
    {
        Task CreateGameRoom(CreateGameViewModel model, UserModel user);
        Task JoinGameRoom(JoinGameViewModel model, UserModel user);
        Task<bool> CheckRoomConnection(int roomId, string connectionId, UserModel user);
    }
}
