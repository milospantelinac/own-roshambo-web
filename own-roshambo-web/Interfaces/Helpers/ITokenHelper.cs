using OwnRoshamboWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Helpers
{
    public interface ITokenHelper
    {
        string GetToken(UserModel user);
        UserModel GetUserFromClaims(IEnumerable<Claim> claims);
    }
}
