using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace OwnRoshamboWeb.Extensions
{
    public static class RegisterJwtAuthIServiceCollectionExtension
    {
        public const string AuthCookieName = "auth_cookie";

        public static IServiceCollection RegisterJwtAuthentication(this IServiceCollection services, string secret, bool requireHttpsMetadata)
        {
            var key = Encoding.ASCII.GetBytes(secret);
            services
                .AddAuthentication(options => {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/Error";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = requireHttpsMetadata;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                    };
                    x.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Cookies.ContainsKey(AuthCookieName))
                            {
                                context.Token = context.Request.Cookies[AuthCookieName];
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return services;
        }
    }
}
