using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InitUserandUserClaimstables : Migration
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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "66745274-4272-4d5f-9b9b-9a92f4eddf58", true, "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "dfda2645-dc43-4ffa-bc0f-679fb2c9efad", true, "Helios", "5BE86359-073C-434B-AD2D-A3932222DABE", "Quentin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("f0f10949-dbd7-49fb-9614-2881dbb6611b"), "4d424141-4766-4b62-be36-5cb92fab3c05", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("c8d716d5-3ab5-4d14-94e8-173fa30d6dc3"), "1457a3cd-a5ce-424a-9f77-79e12eff6360", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("7da35239-7000-45e0-a216-984b3a8e7d33"), "9a81ddb1-bbd2-4e11-9d7d-378465947daa", "role", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "user" },
                    { new Guid("6c155ffc-1782-4971-8e2e-cf020bfe4800"), "6d06df59-f764-4051-b78f-7afb55636941", "given_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin" },
                    { new Guid("7228b0b1-4b68-4183-9b2f-13bf8f0a7a64"), "97f5f6eb-2923-4218-bb9c-224f00c313d1", "family_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Couissinier" },
                    { new Guid("6e23de7a-0b76-4ed7-a7c5-53bd93154f2d"), "35931318-e740-4f35-b395-134e36b91ef7", "role", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "admin" }
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
