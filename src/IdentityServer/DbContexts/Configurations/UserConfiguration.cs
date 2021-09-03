using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace IdentityServer.DbContexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Subject)
                .IsUnique();

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.HasData(
                new User()
                {
                    Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Password = "password",
                    Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Frank",
                    IsActive = true
                },
                new User()
                {
                    Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Password = "password",
                    Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Claire",
                    IsActive = true
                });
        }
    }
}
