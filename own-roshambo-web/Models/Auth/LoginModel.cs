using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Models.Auth
{
    public class LoginModel
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}
