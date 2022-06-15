using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOTApp.Data.Migrations
{
    public partial class AddingCompanyIdToTxEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "TxEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "EmpCommPercent",
                table: "Employees",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerPhone",
                table: "CompanyOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PayTimeFrames",
                columns: table => new
                {
                    PayTFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TFDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TFStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TFEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTimeFrames", x => x.PayTFId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayRates",
                columns: table => new
                {
                    PayTFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PayTimeFramePayTFId = table.Column<int>(type: "int", nullable: false),
                    TFCommPercent = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayRates", x => x.PayTFId);
                    table.ForeignKey(
                        name: "FK_EmployeePayRates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePayRates_PayTimeFrames_PayTimeFramePayTFId",
                        column: x => x.PayTimeFramePayTFId,
                        principalTable: "PayTimeFrames",
                        principalColumn: "PayTFId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeID",
                table: "Contracts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayRates_EmployeeId",
                table: "EmployeePayRates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayRates_PayTimeFramePayTFId",
                table: "EmployeePayRates",
                column: "PayTimeFramePayTFId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Employees_EmployeeID",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "EmployeePayRates");

            migrationBuilder.DropTable(
                name: "PayTimeFrames");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EmployeeID",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "TxEntries");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Contracts");

            migrationBuilder.AlterColumn<decimal>(
                name: "EmpCommPercent",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerPhone",
                table: "CompanyOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
