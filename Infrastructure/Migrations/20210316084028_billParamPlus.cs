using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billParamPlus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillParam_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillParam",
                table: "BillParam");

            migrationBuilder.RenameTable(
                name: "BillParam",
                newName: "BillParams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillParams",
                table: "BillParams",
                columns: new[] { "EnergyLinkObjectToBillPointId", "BillParamType" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParams",
                column: "EnergyLinkObjectToBillPointId",
                principalTable: "EnergyLinkObjectToBillPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillParams",
                table: "BillParams");

            migrationBuilder.RenameTable(
                name: "BillParams",
                newName: "BillParam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillParam",
                table: "BillParam",
                columns: new[] { "EnergyLinkObjectToBillPointId", "BillParamType" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillParam_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParam",
                column: "EnergyLinkObjectToBillPointId",
                principalTable: "EnergyLinkObjectToBillPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
