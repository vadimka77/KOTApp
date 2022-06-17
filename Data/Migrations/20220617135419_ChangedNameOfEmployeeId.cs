using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOTApp.Data.Migrations
{
    public partial class ChangedNameOfEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Contracts",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_EmployeeID",
                table: "Contracts",
                newName: "IX_Contracts_EmployeeId");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyOwnerPercent",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyOwnerAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyOwnerPercent",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployeeID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Contracts",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                newName: "IX_Contracts_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyOwnerPercent",
                table: "Contracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyOwnerAmount",
                table: "Contracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyOwnerPercent",
                table: "Companies",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
