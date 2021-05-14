using OwnRoshamboWeb.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Models.Game
{
    public class GameRoomModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Members { get; set; }
    }
}
