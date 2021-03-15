using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billparam2_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeEntityLinks");
        }
    }
}
