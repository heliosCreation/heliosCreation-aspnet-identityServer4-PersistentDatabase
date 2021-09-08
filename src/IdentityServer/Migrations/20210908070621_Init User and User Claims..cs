using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InitUserandUserClaims : Migration
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
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "14e1ec2c-df2d-4055-be9e-1eda412bcbad", "frank@someProvider.com", true, "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "Email", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "9a1e0192-bdaa-486e-8bc9-a863fdda771d", "quentin@someprovider.com", true, "Helios", "5BE86359-073C-434B-AD2D-A3932222DABE", "Quentin" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("9f5bd15a-11ef-4328-8ba8-c35fe30a8312"), "fb34c06c-4dcb-4e64-9af1-b685664b6351", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("a9768c3a-57b3-457e-8304-29e2d479cf63"), "cfd2795e-55ce-46c8-9046-c1467e1add32", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("836751d7-dc80-470c-beeb-f58d75ff780f"), "8a4dd035-bb21-451d-9a13-07b2b528c6fe", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "En" },
                    { new Guid("e86abbdd-bd7f-4973-a52a-a3ec2fbb10ad"), "511f21fb-05f0-4388-8166-1af7540743c7", "given_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Quentin" },
                    { new Guid("994933bd-ccfc-4251-a9aa-3909a3e482e6"), "f9ff7a42-d2c5-4754-a3f3-ae5b35aa485e", "family_name", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Couissinier" },
                    { new Guid("aa05cc22-f634-4619-8ee6-15a0f0a3a22a"), "ff03cf76-6c63-4eea-b04e-d1650655daf6", "country", new Guid("c6e8040f-b2c0-4986-af6c-d3b650e0927e"), "Fr" }
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
