using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InitUserandclaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 250, nullable: false),
                    Username = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Password = table.Column<string>(maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    SecurityCode = table.Column<string>(nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "IsActive", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "45916a5f-757b-46ae-8aee-958fde07783c", "frank@someProvider.com", true, "AQAAAAEAACcQAAAAEKyU/alhPlQLX31AsXRuntxprzKvIbIJgIjeTS8YTumsUqRoPThoPS74LnHSBMjTVA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "IsActive", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "97d33c9e-2632-4870-aac7-c5776a0fc644", "quentin@someprovider.com", true, "AQAAAAEAACcQAAAAEJnYqlDeDnLqIDR9u5TaqOdi87lAZQDTMprpuTcccPmPdp7+6t5EzqM3nqZEw5B2jQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5BE86359-073C-434B-AD2D-A3932222DABE", "Quentin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("7dcc6ae3-34b3-4b43-a92b-8c920bb01922"), "c4e6d43d-347e-4624-b36a-f8b7368e9c3c", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("05a6581e-b93b-4bd3-b214-22edb0a2c85a"), "c8cd2fd7-8c57-432f-974f-eb8ef2356098", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("283875bc-2800-48ba-90fe-b99b421fa8fa"), "e5189b25-6dc9-4a54-b75d-6cbdb3a58690", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "En" },
                    { new Guid("f659553c-f7f2-4829-a645-dc58f01a3601"), "3ad4f561-5556-4142-89bd-e84857a48210", "given_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin" },
                    { new Guid("deaa654d-5ce5-447f-b88d-acd55644a730"), "1dfb9dce-8103-407b-82a1-3816c8592ada", "family_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Couissinier" },
                    { new Guid("540ba7a2-7519-43c3-aef3-8510c42a4ccd"), "5d5b0a2d-0433-456a-be6c-06b4d61536aa", "country", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Fr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
