using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOTApp.Data.Migrations
{
    public partial class AddedContractFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContractAdvancePercent",
                table: "Contracts",
                newName: "CompanyOwnerPercent");

            migrationBuilder.RenameColumn(
                name: "ContractAdvance",
                table: "Contracts",
                newName: "CompanyOwnerAmount");

            migrationBuilder.RenameColumn(
                name: "CompanyOwnerPay",
                table: "Companies",
                newName: "CompanyOwnerPercent");

            migrationBuilder.AddColumn<decimal>(
                name: "AdvanceAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdvancePercent",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "COTotal",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompletionCertificate",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EmpBalanceAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EmpCommAmount",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EmpCommPercent",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossProfit",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NETSale",
                table: "Contracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployeeAdvancePercent",
                table: "Companies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvanceAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "AdvancePercent",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "COTotal",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CloseDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompletionCertificate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EmpBalanceAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EmpCommAmount",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EmpCommPercent",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GrossProfit",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "NETSale",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EmployeeAdvancePercent",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyOwnerPercent",
                table: "Contracts",
                newName: "ContractAdvancePercent");

            migrationBuilder.RenameColumn(
                name: "CompanyOwnerAmount",
                table: "Contracts",
                newName: "ContractAdvance");

            migrationBuilder.RenameColumn(
                name: "CompanyOwnerPercent",
                table: "Companies",
                newName: "CompanyOwnerPay");
        }
    }
}
