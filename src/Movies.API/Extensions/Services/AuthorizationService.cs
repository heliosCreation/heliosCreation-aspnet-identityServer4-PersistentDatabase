using Microsoft.Extensions.DependencyInjection;

namespace Movies.API.Extensions.Services
{
    public static class AuthorizationService
    {
        public static IServiceCollection AddAuthorizationAndPoliciesService(this IServiceCollection services)
        {
            services.AddAuthorization(option =>
            {
                option.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "movie_api_client", "movies_mvc_client"));
            });

            return services;
        }
    }
}
