using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Game;
using OwnRoshamboWeb.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(DbContextOptions<RoshamboDbContext> options) : base(options)
        {
        }

        public async Task<int> CreateGameRoom(string roomName)
        {
            using (var context = GetContext())
            {
                var gameRoom = await context.GameRoom.SingleOrDefaultAsync(r => r.RoomName == roomName);
                if (gameRoom != null)
                {
                    throw new NotImplementedException();
                }

                var roomId = 1;
                if (await context.GameRoom.AnyAsync())
                {
                    roomId = await context.GameRoom.MaxAsync(r => r.RoomId + 1);
                }

                context.GameRoom.Add(new GameRoom { 
                    RoomId = roomId,
                    RoomName = roomName,
                    Created = DateTimeOffset.Now,
                });
                await context.SaveChangesAsync();
                return roomId;
            }
        }

        public async Task<IEnumerable<GameRoomModel>> GetAllGameRooms()
        {
            using (var context = GetContext())
            {
                var roomList = new List<GameRoomModel>();
                var rooms = await context.Connection.Include(r => r.GameRoom).ToListAsync();  
                var roomGroup = rooms.GroupBy(x => x.RoomId).ToList();

                foreach (var room in rooms)
                {
                    roomList.Add(new GameRoomModel()
                    {
                        RoomId = room.RoomId,
                        RoomName = room.GameRoom.RoomName,
                        Members = roomGroup.Where(t => t.Key == room.RoomId).First().Count()
                    });
                }
                return roomList.DistinctBy(x => x.RoomId);
            }
        }

        public async Task AddConnection(int userId, string connectionId, int roomId)
        {
            using (var context = GetContext())
            {
                var room = await context.GameRoom.SingleOrDefaultAsync(r => r.RoomId == roomId);
                if (room != null)
                {
                    context.Connection.Add(new Connection
                    {
                        UserId = userId,
                        RoomId = room.RoomId,
                        ConnectionId = connectionId,
                        Contected = true,
                    });
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CheckRoomConnection(int roomId, string connectionId, UserModel user)
        {
            using (var context = GetContext())
            {
                var connection = await context.Connection.AsNoTracking().SingleOrDefaultAsync(c => c.UserId == user.Id && c.RoomId == roomId && c.ConnectionId == connectionId);
                if (connection == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
