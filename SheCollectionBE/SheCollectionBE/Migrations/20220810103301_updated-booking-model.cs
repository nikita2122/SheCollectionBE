using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedbookingmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTables_BookingId",
                table: "ServiceTables");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "ServiceTables");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTableId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceTableId",
                table: "Bookings",
                column: "ServiceTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ServiceTables_ServiceTableId",
                table: "Bookings",
                column: "ServiceTableId",
                principalTable: "ServiceTables",
                principalColumn: "ServiceTableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ServiceTables_ServiceTableId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ServiceTableId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ServiceTableId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "ServiceTables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTables_BookingId",
                table: "ServiceTables",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTables_Bookings_BookingId",
                table: "ServiceTables",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }
    }
}
