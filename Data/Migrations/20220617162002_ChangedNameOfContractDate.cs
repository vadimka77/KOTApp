using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOTApp.Data.Migrations
{
    public partial class ChangedNameOfContractDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContractDate",
                table: "Contracts",
                newName: "StartDate");

            migrationBuilder.CreateTable(
                name: "ChangeOrders",
                columns: table => new
                {
                    ChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeOrders", x => x.ChangeId);
                    table.ForeignKey(
                        name: "FK_ChangeOrders_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeOrders_ContractId",
                table: "ChangeOrders",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeOrders");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Contracts",
                newName: "ContractDate");
        }
    }
}
