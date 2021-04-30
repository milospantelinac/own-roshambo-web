using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnRoshamboWeb.Repositories.Models
{
    public class Connection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConnectionId { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [MaxLength(255)]
        public string UserAgent { get; set; }

        public bool Contected { get; set; }
    }
}
