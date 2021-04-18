using Microsoft.Extensions.DependencyInjection;
using OwnRoshamboWeb.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using OwnRoshamboWeb.Interfaces.Repositories;

namespace OwnRoshamboWeb.Extensions
{
    public static class RegisterRepositoriesExtension
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<RoshamboDbContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<IUserRepository, UserRepository>();
        }
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RoshamboDbContext>();
                context.Database.Migrate();
            }
            return builder;
        }
    }
}
