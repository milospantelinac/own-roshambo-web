using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Interfaces.Helpers
{
    public interface IPasswordHelper
    {
        byte[] HasPassword(string password);

    }
}
