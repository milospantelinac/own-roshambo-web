using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Interfaces.Repositories;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.Models;
using OwnRoshamboWeb.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwprdHelper;
        private readonly ITokenHelper _tokenHelper;
        public AuthService(IUserRepository userRepository, IPasswordHelper passwprdHelper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _passwprdHelper = passwprdHelper;
            _tokenHelper = tokenHelper;
        }
        public async Task<LoginModel> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email, _passwprdHelper.HasPassword(password));

            if (user == null)
            {
                throw new ApplicationException("Email or password is not valid.");
            }

            return new LoginModel
            {
                User = user,
                Token = _tokenHelper.GetToken(user)
            };
        }
    }
}
