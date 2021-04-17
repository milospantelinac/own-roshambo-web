using OwnRoshamboWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserModel> Login(string email, string password);
    }
}
