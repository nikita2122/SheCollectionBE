using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheCollectionBE.Migrations
{
    public partial class iiiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserTables_UserTableId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "UserTableId",
                table: "Employees",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserTableId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "EmployeeTypeDescription", "EmployeeTypeName" },
                values: new object[] { 1, "hair dresser", "braider" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeEmail", "EmployeeName", "EmployeeNumber", "EmployeeSurname", "EmployeeTypeId", "UserId" },
                values: new object[] { 1, "a@gmail.com", "Admin", "10199", "Admin", 1, 10 });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserTables_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "UserTables",
                principalColumn: "UserTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserTables_UserId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeTypes",
                keyColumn: "EmployeeTypeId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employees",
                newName: "UserTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                newName: "IX_Employees_UserTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserTables_UserTableId",
                table: "Employees",
                column: "UserTableId",
                principalTable: "UserTables",
                principalColumn: "UserTableId");
        }
    }
}
