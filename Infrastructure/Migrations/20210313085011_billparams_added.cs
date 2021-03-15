using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billparams_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillParamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillParamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillParams",
                columns: table => new
                {
                    EnergyLinkObjectToBillPointId = table.Column<int>(type: "int", nullable: false),
                    BillParamTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillParams", x => new { x.EnergyLinkObjectToBillPointId, x.BillParamTypeId });
                    table.ForeignKey(
                        name: "FK_BillParams_BillParamTypes_BillParamTypeId",
                        column: x => x.BillParamTypeId,
                        principalTable: "BillParamTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                        column: x => x.EnergyLinkObjectToBillPointId,
                        principalTable: "EnergyLinkObjectToBillPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillParamTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ценовая категория" },
                    { 2, "Тарифный уровень напряжения" },
                    { 3, "Знак вхождения" },
                    { 4, "Категория мощности" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillParams_BillParamTypeId",
                table: "BillParams",
                column: "BillParamTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillParams");

            migrationBuilder.DropTable(
                name: "BillParamTypes");
        }
    }
}
