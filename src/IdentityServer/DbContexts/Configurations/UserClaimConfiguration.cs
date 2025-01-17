﻿using IdentityModel;
using IdentityServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace IdentityServer.DbContexts.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasData(GenerateClaimSeeds());
        }


        private List<UserClaim> GenerateClaimSeeds()
        {
            return new List<UserClaim>()
            {
                //Frank's Claims
                new UserClaim()
                {
                     Id = Guid.NewGuid(),
                     UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                     Type = JwtClaimTypes.GivenName,
                     Value = "Frank"
                },
                new UserClaim()
                {
                     Id = Guid.NewGuid(),
                     UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                     Type = JwtClaimTypes.FamilyName,
                     Value = "Underwood"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "country",
                    Value = "En"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = JwtClaimTypes.Address,
                    Value = "12 hacker way"
                },

                //Quentin's Claims
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Type = JwtClaimTypes.GivenName,
                    Value = "Quentin"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Type = JwtClaimTypes.FamilyName,
                    Value = "Couissinier"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Type = "country",
                    Value = "Fr"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Type = JwtClaimTypes.Address,
                    Value = "13 hacker way"
                },
            };
        }
    }
}

