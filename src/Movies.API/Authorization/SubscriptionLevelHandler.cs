using Microsoft.AspNetCore.Authorization;
using Movies.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Authorization
{
    public class SubscriptionLevelHandler : AuthorizationHandler<SubscriptionLevelRequirement>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IApplicationUserProfileService _applicationUserProfileService;

        public SubscriptionLevelHandler(
            ILoggedInUserService loggedInUserService,
            IApplicationUserProfileService applicationUserProfileService)
        {
            _loggedInUserService = loggedInUserService ?? throw new ArgumentNullException(nameof(loggedInUserService));
            _applicationUserProfileService = applicationUserProfileService ?? throw new ArgumentNullException(nameof(applicationUserProfileService));
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubscriptionLevelRequirement requirement)
        {
            var sub = _loggedInUserService.getUserSub();
            var profile = _applicationUserProfileService.GetApplicationUserProfile(sub);

            if (profile.SubscriptionLevel != requirement.SubscriptionLevel)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;

        }
    }
}
