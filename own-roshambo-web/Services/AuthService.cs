using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserModel> Login(string email, string password)
        {

            //return _userRepository.GetUserByEmail(email,);
            return null;
        }
    }
}
