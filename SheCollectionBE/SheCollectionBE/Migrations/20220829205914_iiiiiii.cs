using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class iiiiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "BookingStatusId", "BookingStatusName" },
                values: new object[] { 1, "Upcoming" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingStatuses",
                keyColumn: "BookingStatusId",
                keyValue: 1);
        }
    }
}
