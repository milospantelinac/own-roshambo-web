using OwnRoshamboWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByEmail(string email, byte[] passowrd);
    }
}
