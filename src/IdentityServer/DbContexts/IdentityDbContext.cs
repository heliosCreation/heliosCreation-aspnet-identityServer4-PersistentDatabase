using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer.DbContexts
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified)
                    .OfType<IConcurrencyAware>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
