﻿// <auto-generated />
using System;
using IdentityServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityServer.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20210908092826_Init User and claims")]
    partial class InitUserandclaims
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "45916a5f-757b-46ae-8aee-958fde07783c",
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
                            ConcurrencyStamp = "97d33c9e-2632-4870-aac7-c5776a0fc644",
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
                            Id = new Guid("7dcc6ae3-34b3-4b43-a92b-8c920bb01922"),
                            ConcurrencyStamp = "c4e6d43d-347e-4624-b36a-f8b7368e9c3c",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Frank"
                        },
                        new
                        {
                            Id = new Guid("05a6581e-b93b-4bd3-b214-22edb0a2c85a"),
                            ConcurrencyStamp = "c8cd2fd7-8c57-432f-974f-eb8ef2356098",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Underwood"
                        },
                        new
                        {
                            Id = new Guid("283875bc-2800-48ba-90fe-b99b421fa8fa"),
                            ConcurrencyStamp = "e5189b25-6dc9-4a54-b75d-6cbdb3a58690",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "En"
                        },
                        new
                        {
                            Id = new Guid("f659553c-f7f2-4829-a645-dc58f01a3601"),
                            ConcurrencyStamp = "3ad4f561-5556-4142-89bd-e84857a48210",
                            Type = "given_name",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Quentin"
                        },
                        new
                        {
                            Id = new Guid("deaa654d-5ce5-447f-b88d-acd55644a730"),
                            ConcurrencyStamp = "1dfb9dce-8103-407b-82a1-3816c8592ada",
                            Type = "family_name",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Couissinier"
                        },
                        new
                        {
                            Id = new Guid("540ba7a2-7519-43c3-aef3-8510c42a4ccd"),
                            ConcurrencyStamp = "5d5b0a2d-0433-456a-be6c-06b4d61536aa",
                            Type = "country",
                            UserId = new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"),
                            Value = "Fr"
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