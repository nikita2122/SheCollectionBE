using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_OrderTables_OrderId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "TotalOrderQuantity",
                table: "OrderTables");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderTableId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ColourId",
                table: "OrderLines",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderTableId",
                table: "OrderLines",
                column: "OrderTableId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_SizeId",
                table: "OrderLines",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Colours_ColourId",
                table: "OrderLines",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_OrderTables_OrderTableId",
                table: "OrderLines",
                column: "OrderTableId",
                principalTable: "OrderTables",
                principalColumn: "OrderTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Sizes_SizeId",
                table: "OrderLines",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Colours_ColourId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_OrderTables_OrderTableId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Products_ProductId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Sizes_SizeId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ColourId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderTableId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_SizeId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "OrderTableId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "OrderLines");

            migrationBuilder.AddColumn<int>(
                name: "TotalOrderQuantity",
                table: "OrderTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_OrderTables_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "OrderTables",
                principalColumn: "OrderTableId");
        }
    }
}
