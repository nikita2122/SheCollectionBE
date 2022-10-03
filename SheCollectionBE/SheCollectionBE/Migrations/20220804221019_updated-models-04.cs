using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class updatedmodels04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserTables_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_DateTables_DateId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DateId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employees",
                newName: "UserTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                newName: "IX_Employees_UserTableId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Schedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserTables_UserTableId",
                table: "Employees",
                column: "UserTableId",
                principalTable: "UserTables",
                principalColumn: "UserTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserTables_UserTableId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "UserTableId",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserTableId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DateId",
                table: "Schedules",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserTables_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_DateTables_DateId",
                table: "Schedules",
                column: "DateId",
                principalTable: "DateTables",
                principalColumn: "DateTableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
