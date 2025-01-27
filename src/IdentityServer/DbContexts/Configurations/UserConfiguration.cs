﻿using IdentityServer.Entities;
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

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.HasData(
                new User()
                {
                    Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Email = "frank@someProvider.com",
                    Password = "AQAAAAEAACcQAAAAEKyU/alhPlQLX31AsXRuntxprzKvIbIJgIjeTS8YTumsUqRoPThoPS74LnHSBMjTVA==",//password
                    Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Frank",
                    IsActive = true
                },
                new User
                {
                    Id = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Email = "quentin@someprovider.com",
                    Subject = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "Quentin",
                    Password = "AQAAAAEAACcQAAAAEJnYqlDeDnLqIDR9u5TaqOdi87lAZQDTMprpuTcccPmPdp7+6t5EzqM3nqZEw5B2jQ==",//Helios
                    IsActive = true
                });
        }
    }
}
