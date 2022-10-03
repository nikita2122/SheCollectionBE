using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "TitleId", "TitleName" },
                values: new object[,]
                {
                    { 1, "Mr" },
                    { 2, "Mrs" },
                    { 3, "Dr" },
                    { 4, "Ms" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "UserTables",
                columns: new[] { "UserTableId", "Picture", "UserName", "UserPassword", "UserRoleId" },
                values: new object[] { 10, "", "Admin", "jr3s59rncvdb4YEDu7HkbH/cFzfANGXg61rsp6X7h1A=", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "TitleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTables",
                keyColumn: "UserTableId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1);
        }
    }
}
