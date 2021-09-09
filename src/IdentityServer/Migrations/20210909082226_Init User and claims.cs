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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "0aa9d598-d159-4cb8-ad6c-026a6ea4be41", "frank@someProvider.com", true, "AQAAAAEAACcQAAAAEKyU/alhPlQLX31AsXRuntxprzKvIbIJgIjeTS8YTumsUqRoPThoPS74LnHSBMjTVA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "IsActive", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "Username" },
                values: new object[] { new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "f0cbf832-c63f-4255-bdd0-5d5b8e84add0", "quentin@someprovider.com", true, "AQAAAAEAACcQAAAAEJnYqlDeDnLqIDR9u5TaqOdi87lAZQDTMprpuTcccPmPdp7+6t5EzqM3nqZEw5B2jQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5BE86359-073C-434B-AD2D-A3932222DABE", "Quentin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("46e955f9-fe58-461f-a2a3-d1e4f7a6a3aa"), "c2d322fe-2098-4dcb-862c-f0dce4399700", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("0629061e-3f3c-4b29-a674-a0f375ab2d97"), "529a689e-2582-4bef-b3b2-9c272361739e", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("8d9f04b3-1ddd-48d2-9527-4ae8c5ca0634"), "aff15293-0a8b-4b57-b2a5-f312e55dde15", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "En" },
                    { new Guid("38a7afa0-f046-4546-adcc-68eec0f1dea3"), "3090318e-1e8f-4f28-8cf8-3f29273eb10b", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "12 hacker way" },
                    { new Guid("7725582b-e7cc-4f36-943c-71dba8f1d4eb"), "f4970a49-c1ef-4849-b46a-e2e82bd0f771", "given_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin" },
                    { new Guid("eb4d28f0-2179-4479-a2f9-03018a24e886"), "2d31b16a-719c-4703-b5a3-c332cc08f14d", "family_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Couissinier" },
                    { new Guid("57d2af77-6083-4f99-beb1-bbfdfe36a01b"), "561794cc-6b76-4e74-9295-d6e5abfc6d99", "country", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Fr" },
                    { new Guid("b372225f-d928-448b-bf4d-6a29e1a846dc"), "91187d2e-975b-42e8-9d55-38fe192e72b8", "address", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "13 hacker way" }
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
