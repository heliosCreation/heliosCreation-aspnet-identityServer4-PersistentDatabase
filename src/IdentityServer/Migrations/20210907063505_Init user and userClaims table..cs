using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InituseranduserClaimstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
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
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "3fffbbf3-7d05-4b27-b419-930cb036e837", true, "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "85032bef-d0fa-4b10-bae9-914e47a8a0b0", true, "Helios", "5BE86359-073C-434B-AD2D-A3932222DABE", "Quentin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("09402969-6b79-426f-9ec3-92d7dfd5df2f"), "61fdbf3d-acee-4ce9-9154-b136ea184af5", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("bc4f03f3-057a-4482-a77a-0fdba8f7239f"), "0378facc-1a16-4ae1-8c2c-812eb020ff36", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("9af19235-b344-4f39-b71e-0ecd13658e36"), "7161170f-4059-40a5-bf5a-a37437de6143", "email", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FrankUnderwood@someProvider.com" },
                    { new Guid("9834ee0e-ba76-4e8d-8d19-22bdb94cf480"), "aa29e987-ad8d-4cce-9335-21eac80ee3c6", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "En" },
                    { new Guid("d58f23ca-f25d-4730-9a4b-0de367523fdb"), "6c416774-4f1b-40f8-bf3a-b8f5152efb46", "given_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin" },
                    { new Guid("62e3e514-810d-4358-95ad-bcd31ab5026c"), "290bfe87-5d08-4e87-bcd1-79a49d55b768", "family_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Couissinier" },
                    { new Guid("dbad180e-09cd-49a3-be96-a5300ab7a818"), "7dc991ae-b070-4039-8033-d21bab6c774e", "email", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin.couissinier@someProvider.com" },
                    { new Guid("33367cc5-aa93-4bc7-9cc2-cec41bd32ea1"), "8fafe672-1734-47fc-bbf2-924b532a8b79", "country", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Fr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

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
