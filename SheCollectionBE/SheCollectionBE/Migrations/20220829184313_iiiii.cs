using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class iiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceTables",
                columns: new[] { "ServiceTableId", "DurationMax", "DurationMin", "ServiceDescription", "ServiceName", "ServicePicture", "ServicePrice", "ServiceTypeId" },
                values: new object[] { 1, 10f, 5f, " ext", "Hair extending", "", 499.99m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceTables",
                keyColumn: "ServiceTableId",
                keyValue: 1);
        }
    }
}
