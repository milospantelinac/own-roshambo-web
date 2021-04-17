using Microsoft.Extensions.Options;
using OwnRoshamboWeb.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OwnRoshamboWeb.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        private readonly AppSettings _appSettings;
        public PasswordHelper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public byte[] HasPassword(string password)
        {
            var passwordWithSalt = $"{password}{_appSettings.PasswordSalt}";
            if(!string.IsNullOrEmpty(passwordWithSalt))
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
