using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ServiceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "ServiceTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ServiceTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ServiceCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ServiceTables");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ServiceCategories");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "ServiceTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
