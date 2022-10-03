using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class iii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "ServiceCategoryId", "ServiceCategoryDescription", "ServiceCategoryName", "imgUrl" },
                values: new object[] { 1, "Braiding or extending", "Hair platting", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceCategories",
                keyColumn: "ServiceCategoryId",
                keyValue: 1);
        }
    }
}
