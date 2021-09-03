using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InitUserandUserClaimsTable : Migration
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
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "3425734c-5485-4958-b3a2-6ff289f87e46", true, "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "Frank" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "Password", "Subject", "Username" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "b9bcbbb1-50d1-4d20-9fa8-0eb9c79f5fff", true, "password", "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Claire" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("8c4fcea0-102a-4da9-aa08-1b6a1afc7ad9"), "990557bc-fcd3-4859-a006-665c6c9d4559", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Frank" },
                    { new Guid("a5d98106-b3ac-43b0-bdf7-c7c6a889239b"), "e760492f-c3f5-4ad2-a325-7f79746230c7", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Underwood" },
                    { new Guid("38e482eb-7a9e-4e05-87a2-e661dba075cb"), "da9efaf2-8b9c-468c-b1bf-80918805b012", "address", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Main Road 1" },
                    { new Guid("0ac3ee14-1e7c-4e80-ac34-646f1791c36e"), "87a9b4ee-e6dd-4f58-a9f4-daf0b579203a", "subscriptionlevel", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("c9782fc2-ed78-4f05-8857-be53613287f8"), "5add7373-2b21-4379-9eb8-491cc3d2ca82", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("a4854229-f6d1-4a39-8897-beed0af9a282"), "16881204-b8cd-4cc5-8940-d80dc1fdc4f7", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Claire" },
                    { new Guid("48c90ea2-2721-4e8a-9894-5ad735a722be"), "b1b04174-1ed0-4eb2-a9f4-d870df149387", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Underwood" },
                    { new Guid("4e8fd0fd-7ddd-4559-a897-14506a517a07"), "bd891933-3489-4c11-b51d-fb64496e9eba", "address", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Big Street 2" },
                    { new Guid("18e1718f-20ff-4672-b018-368663f51434"), "ba662c58-3290-475b-a770-372e2acc229a", "subscriptionlevel", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("b9c951d0-c21d-4910-a7c4-be9f224e1aa9"), "ce012372-7de4-4215-9716-fd19ecbae012", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
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
