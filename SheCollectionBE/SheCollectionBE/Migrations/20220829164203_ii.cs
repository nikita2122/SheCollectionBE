using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class ii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "ColourId", "ColourName" },
                values: new object[,]
                {
                    { 1, "RED" },
                    { 2, "GREEN" },
                    { 3, "BLUE" },
                    { 4, "BROWN" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "ProductCategoryDescription", "ProductCategoryName", "imgUrl" },
                values: new object[,]
                {
                    { 1, "hair care items", "hair care", "" },
                    { 2, "nail care items", "nail care", "" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "SizeName" },
                values: new object[,]
                {
                    { 1, "S" },
                    { 2, "M" },
                    { 3, "L" },
                    { 4, "XL" },
                    { 5, "XXL" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "ProductCategoryId", "ProductTypeName", "imgUrl" },
                values: new object[] { 1, 1, "Single use", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "SizeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 1);
        }
    }
}
