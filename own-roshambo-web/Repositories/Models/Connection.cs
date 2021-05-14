using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnRoshamboWeb.Repositories.Models
{
    public class Connection
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RoomId { get; set; }
        public virtual GameRoom GameRoom { get; set; }
        public string ConnectionId { get; set; }

        [MaxLength(255)]
        public string UserAgent { get; set; }

        public bool Contected { get; set; }
    }
}
