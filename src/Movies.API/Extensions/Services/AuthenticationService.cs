using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Movies.API.Extensions.Services
{
    public static class AuthenticationService
    {
        public static IServiceCollection AddBearerAuthenticationService(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer(opt =>
                {
                    opt.Authority = "https://localhost:5005";
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            return services;
        }
    }
}
