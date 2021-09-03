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
                new UserClaim()
                {
                     Id = Guid.NewGuid(),
                     UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                     Type = "given_name",
                     Value = "Frank"
                },
                new UserClaim()
                {
                     Id = Guid.NewGuid(),
                     UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                     Type = "family_name",
                     Value = "Underwood"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "address",
                    Value = "Main Road 1"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "subscriptionlevel",
                    Value = "FreeUser"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Type = "country",
                    Value = "nl"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "given_name",
                    Value = "Claire"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "family_name",
                    Value = "Underwood"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "address",
                    Value = "Big Street 2"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "subscriptionlevel",
                    Value = "PayingUser"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Type = "country",
                    Value = "be"
                }
            };
        }
    }
}

