using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedmodels03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "ServiceTables",
                newName: "DurationMin");

            migrationBuilder.AddColumn<float>(
                name: "DurationMax",
                table: "ServiceTables",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMax",
                table: "ServiceTables");

            migrationBuilder.RenameColumn(
                name: "DurationMin",
                table: "ServiceTables",
                newName: "Duration");
        }
    }
}
