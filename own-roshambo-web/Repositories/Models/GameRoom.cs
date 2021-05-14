using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnRoshamboWeb.Repositories.Models
{
    public class GameRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
