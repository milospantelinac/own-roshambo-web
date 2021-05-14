using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OwnRoshamboWeb.Repositories.Models;
using System.Security.Cryptography;
using System.Text;

namespace OwnRoshamboWeb.Repositories
{
    public class RoshamboDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<GameRoom> GameRoom { get; set; }
        public DbSet<Connection> Connection { get; set; }

        public RoshamboDbContext(DbContextOptions<RoshamboDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<Connection>().HasKey(x => new { x.UserId, x.RoomId, x.ConnectionId });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "John94",
                Email = "john@example.com",
                Password = HasPassword("john123"),
                IsActive = true,
                Score = 0,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Username = "Nikolas89",
                Email = "nikolas@example.com",
                Password = HasPassword("nikolas123"),
                IsActive = true,
                Score = 0,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                Username = "Tom78",
                Email = "tom@example.com",
                Password = HasPassword("tom123"),
                IsActive = true,
                Score = 0,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                Username = "Ellena",
                Email = "ellena@example.com",
                Password = HasPassword("ellena123"),
                IsActive = true,
                Score = 0,
            });
        }

        private byte[] HasPassword(string password)
        {
            var passwordWithSalt = $"{password}8jrxT9mDEMhkLrqxUr8wxsg5bt3uqZ";
            if (!string.IsNullOrEmpty(passwordWithSalt))
            {
                using (var SHA1 = new SHA1CryptoServiceProvider())
                {
                    byte[] buffer = Encoding.Default.GetBytes(passwordWithSalt);
                    return SHA1.ComputeHash(buffer);
                }
            }
            return null;
        }
    }
}
