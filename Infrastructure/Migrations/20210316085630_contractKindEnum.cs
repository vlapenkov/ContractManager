using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class contractKindEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractKinds_ContractKindId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractKinds");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ContractKindId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractKindId",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "ContractKind",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractKind",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "ContractKindId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractKinds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ContractKinds",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Договор энергоснабжения" });

            migrationBuilder.InsertData(
                table: "ContractKinds",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Договор купили-продажи" });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractKindId",
                table: "Contracts",
                column: "ContractKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractKinds_ContractKindId",
                table: "Contracts",
                column: "ContractKindId",
                principalTable: "ContractKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
