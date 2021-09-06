using IdentityModel;
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

        //Claims = new List<Claim>
        //                {
        //                    new Claim(JwtClaimTypes.GivenName, "Quentin"),
        //                    new Claim(JwtClaimTypes.FamilyName, "Couissinier"),
        //                    new Claim(JwtClaimTypes.Email, "quentin.couissinier@email.com"),
        //                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
        //                    new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
        //                    new Claim(JwtClaimTypes.Role, "admin")

        //                }
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
                    UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                    Type = JwtClaimTypes.Role,
                    Value = "user"
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
                    Type = JwtClaimTypes.Role,
                    Value = "admin"
                },
            };
        }
    }
}

