using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginModel> Login(string email, string password);
    }
}
