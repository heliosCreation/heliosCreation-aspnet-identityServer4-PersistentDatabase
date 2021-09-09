﻿// <auto-generated />
using System;
using IdentityServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityServer.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SecurityCodeExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            ConcurrencyStamp = "0aa9d598-d159-4cb8-ad6c-026a6ea4be41",
                            Email = "frank@someProvider.com",
                            IsActive = true,
                            Password = "AQAAAAEAACcQAAAAEKyU/alhPlQLX31AsXRuntxprzKvIbIJgIjeTS8YTumsUqRoPThoPS74LnHSBMjTVA==",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            Username = "Frank"
                        },
                        new
                        {
                            Id = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            ConcurrencyStamp = "f0cbf832-c63f-4255-bdd0-5d5b8e84add0",
                            Email = "quentin@someprovider.com",
                            IsActive = true,
                            Password = "AQAAAAEAACcQAAAAEJnYqlDeDnLqIDR9u5TaqOdi87lAZQDTMprpuTcccPmPdp7+6t5EzqM3nqZEw5B2jQ==",
                            SecurityCodeExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "5BE86359-073C-434B-AD2D-A3932222DABE",
                            Username = "Quentin"
                        });
                });

            modelBuilder.Entity("IdentityServer.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46e955f9-fe58-461f-a2a3-d1e4f7a6a3aa"),
                            ConcurrencyStamp = "c2d322fe-2098-4dcb-862c-f0dce4399700",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Frank"
                        },
                        new
                        {
                            Id = new Guid("0629061e-3f3c-4b29-a674-a0f375ab2d97"),
                            ConcurrencyStamp = "529a689e-2582-4bef-b3b2-9c272361739e",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Underwood"
                        },
                        new
                        {
                            Id = new Guid("8d9f04b3-1ddd-48d2-9527-4ae8c5ca0634"),
                            ConcurrencyStamp = "aff15293-0a8b-4b57-b2a5-f312e55dde15",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "En"
                        },
                        new
                        {
                            Id = new Guid("38a7afa0-f046-4546-adcc-68eec0f1dea3"),
                            ConcurrencyStamp = "3090318e-1e8f-4f28-8cf8-3f29273eb10b",
                            Type = "address",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "12 hacker way"
                        },
                        new
                        {
                            Id = new Guid("7725582b-e7cc-4f36-943c-71dba8f1d4eb"),
                            ConcurrencyStamp = "f4970a49-c1ef-4849-b46a-e2e82bd0f771",
                            Type = "given_name",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Quentin"
                        },
                        new
                        {
                            Id = new Guid("eb4d28f0-2179-4479-a2f9-03018a24e886"),
                            ConcurrencyStamp = "2d31b16a-719c-4703-b5a3-c332cc08f14d",
                            Type = "family_name",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Couissinier"
                        },
                        new
                        {
                            Id = new Guid("57d2af77-6083-4f99-beb1-bbfdfe36a01b"),
                            ConcurrencyStamp = "561794cc-6b76-4e74-9295-d6e5abfc6d99",
                            Type = "country",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Fr"
                        },
                        new
                        {
                            Id = new Guid("b372225f-d928-448b-bf4d-6a29e1a846dc"),
                            ConcurrencyStamp = "91187d2e-975b-42e8-9d55-38fe192e72b8",
                            Type = "address",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "13 hacker way"
                        });
                });

            modelBuilder.Entity("IdentityServer.Entities.UserClaim", b =>
                {
                    b.HasOne("IdentityServer.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
