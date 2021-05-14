using Microsoft.Extensions.DependencyInjection;
using OwnRoshamboWeb.Helpers;
using OwnRoshamboWeb.Hubs;
using OwnRoshamboWeb.Interfaces.Helpers;
using OwnRoshamboWeb.Interfaces.Hubs;
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
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IGameService, GameService>()
                .AddScoped<IGameHub, GameHub>();
        }
    }
}
