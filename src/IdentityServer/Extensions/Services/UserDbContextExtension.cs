using IdentityServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Extensions.Services
{
    public static class UserDbContextExtension
    {
        public static IServiceCollection AddUserSqlDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
