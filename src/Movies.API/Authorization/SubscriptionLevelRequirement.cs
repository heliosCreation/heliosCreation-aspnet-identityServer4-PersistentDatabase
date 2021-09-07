using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Authorization
{
    public class SubscriptionLevelRequirement : IAuthorizationRequirement
    {
        public string SubscriptionLevel { get; set; }
        public SubscriptionLevelRequirement(string subscriptionLevel)
        {
            SubscriptionLevel = subscriptionLevel;
        }
    }
}
