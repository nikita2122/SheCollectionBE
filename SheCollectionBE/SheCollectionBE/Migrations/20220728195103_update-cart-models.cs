using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatecartmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColours_Colours_ColourId",
                table: "ProductColours");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColours_Products_ProductId",
                table: "ProductColours");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Sizes_SizeId",
                table: "ProductSizes");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "ProductSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductSizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductColours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColourId",
                table: "ProductColours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTableId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "CartLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "CartLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserTableId",
                table: "Carts",
                column: "UserTableId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_ColourId",
                table: "CartLines",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_SizeId",
                table: "CartLines",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLines_Colours_ColourId",
                table: "CartLines",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartLines_Sizes_SizeId",
                table: "CartLines",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_UserTables_UserTableId",
                table: "Carts",
                column: "UserTableId",
                principalTable: "UserTables",
                principalColumn: "UserTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColours_Colours_ColourId",
                table: "ProductColours",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColours_Products_ProductId",
                table: "ProductColours",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Sizes_SizeId",
                table: "ProductSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLines_Colours_ColourId",
                table: "CartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_CartLines_Sizes_SizeId",
                table: "CartLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_UserTables_UserTableId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColours_Colours_ColourId",
                table: "ProductColours");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColours_Products_ProductId",
                table: "ProductColours");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Sizes_SizeId",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserTableId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_CartLines_ColourId",
                table: "CartLines");

            migrationBuilder.DropIndex(
                name: "IX_CartLines_SizeId",
                table: "CartLines");

            migrationBuilder.DropColumn(
                name: "UserTableId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "CartLines");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "CartLines");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "ProductSizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductSizes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTypeId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductColours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColourId",
                table: "ProductColours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColours_Colours_ColourId",
                table: "ProductColours",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColours_Products_ProductId",
                table: "ProductColours",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Sizes_SizeId",
                table: "ProductSizes",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId");
        }
    }
}
