using Microsoft.Extensions.DependencyInjection;
using OwnRoshamboWeb.Helpers;
using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Interfaces.Services;
using OwnRoshamboWeb.Services;

namespace OwnRoshamboWeb.Extensions
{
    public static class RegiterServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IPasswordHelper, PasswordHelper>()
                .AddScoped<ITokenHelper, TokenHelper>()
                .AddScoped<IAuthService, AuthService>();
        }
    }
}
