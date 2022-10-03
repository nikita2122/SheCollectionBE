using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class iiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "ServiceCategoryId", "ServiceTypeName", "imgUrl" },
                values: new object[] { 1, 1, "Hair extending", "" });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "ServiceCategoryId", "ServiceTypeName", "imgUrl" },
                values: new object[] { 2, 1, "Hair braiding", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 2);
        }
    }
}
