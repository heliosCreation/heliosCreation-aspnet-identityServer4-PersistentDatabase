using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Movies.API.Authorization;

namespace Movies.API.Extensions.Services
{
    public static class AuthorizationService
    {
        public static IServiceCollection AddAuthorizationAndPoliciesService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, SubscriptionLevelHandler>();

            services.AddAuthorization(option =>
            {
                option.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "movie_api_client", "movies_mvc_client"));

                option.AddPolicy(
                "MustBePayingUser",
                policyBuilder =>
                {
                    policyBuilder.RequireAuthenticatedUser();
                    policyBuilder.AddRequirements(
                        new SubscriptionLevelRequirement("PayingUser"));
                });
            });



            return services;
        }
    }
}
