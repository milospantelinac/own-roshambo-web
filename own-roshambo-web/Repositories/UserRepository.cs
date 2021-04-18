using Microsoft.EntityFrameworkCore;
using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DbContextOptions<RoshamboDbContext> options) : base(options)
        {
        }

        public async Task<UserModel> GetUserByEmail(string email, byte[] passowrd)
        {
            using(var context = GetContext())
            {
                return await context.Users.Where(u => u.Email == email && u.Password == passowrd).Select(u => new UserModel
                {
                     Id = u.Id,
                     Username = u.Username,
                     Email = u.Email,
                     Score = u.Score,
                     IsActive = u.IsActive
                }).SingleOrDefaultAsync();
            }
        }
    }
}
