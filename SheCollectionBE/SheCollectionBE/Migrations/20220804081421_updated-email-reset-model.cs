using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedemailresetmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "EmailResetTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "EmailResetTable");
        }
    }
}
