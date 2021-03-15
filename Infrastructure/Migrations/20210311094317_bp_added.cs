using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class bp_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TnePointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLinkObjectToBillPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnergyLinkObjectId = table.Column<int>(type: "int", nullable: false),
                    BillPointId = table.Column<int>(type: "int", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLinkObjectToBillPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLinkObjectToBillPoint_BillPoints_BillPointId",
                        column: x => x.BillPointId,
                        principalTable: "BillPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnergyLinkObjectToBillPoint_EnergyLinkObjects_EnergyLinkObjectId",
                        column: x => x.EnergyLinkObjectId,
                        principalTable: "EnergyLinkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillPoints",
                columns: new[] { "Id", "Name", "TnePointId" },
                values: new object[] { 1, "bp1", 1 });

            migrationBuilder.InsertData(
                table: "BillPoints",
                columns: new[] { "Id", "Name", "TnePointId" },
                values: new object[] { 2, "bp1", 2 });

            migrationBuilder.InsertData(
                table: "BillPoints",
                columns: new[] { "Id", "Name", "TnePointId" },
                values: new object[] { 3, "bp1", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLinkObjectToBillPoint_BillPointId",
                table: "EnergyLinkObjectToBillPoint",
                column: "BillPointId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLinkObjectToBillPoint_EnergyLinkObjectId",
                table: "EnergyLinkObjectToBillPoint",
                column: "EnergyLinkObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyLinkObjectToBillPoint");

            migrationBuilder.DropTable(
                name: "BillPoints");
        }
    }
}
