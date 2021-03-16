using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billParamType_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParams");

            migrationBuilder.DropTable(
                name: "FakeEntityLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillParams",
                table: "BillParams");

            migrationBuilder.RenameTable(
                name: "BillParams",
                newName: "BillParam");

            migrationBuilder.RenameColumn(
                name: "BillParamTypeId",
                table: "BillParam",
                newName: "BillParamType");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "BillParamType",
                table: "BillParams",
                newName: "BillParamTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillParams",
                table: "BillParams",
                columns: new[] { "EnergyLinkObjectToBillPointId", "BillParamTypeId" });

            migrationBuilder.CreateTable(
                name: "FakeEntityLinks",
                columns: table => new
                {
                    FakeEntityId = table.Column<int>(type: "int", nullable: false),
                    BillParamTypeEnum2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeEntityLinks", x => new { x.FakeEntityId, x.BillParamTypeEnum2 });
                    table.ForeignKey(
                        name: "FK_FakeEntityLinks_FakeEntities_FakeEntityId",
                        column: x => x.FakeEntityId,
                        principalTable: "FakeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                table: "BillParams",
                column: "EnergyLinkObjectToBillPointId",
                principalTable: "EnergyLinkObjectToBillPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
