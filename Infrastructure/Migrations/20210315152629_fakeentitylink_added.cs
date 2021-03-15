using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class fakeentitylink_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillParamTypeEnum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillParamTypeEnum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FakeEntityLinks",
                columns: table => new
                {
                    FakeEntityId = table.Column<int>(type: "int", nullable: false),
                    BillParamTypeEnumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeEntityLinks", x => new { x.FakeEntityId, x.BillParamTypeEnumId });
                    table.ForeignKey(
                        name: "FK_FakeEntityLinks_BillParamTypeEnum_BillParamTypeEnumId",
                        column: x => x.BillParamTypeEnumId,
                        principalTable: "BillParamTypeEnum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FakeEntityLinks_FakeEntities_FakeEntityId",
                        column: x => x.FakeEntityId,
                        principalTable: "FakeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FakeEntityLinks_BillParamTypeEnumId",
                table: "FakeEntityLinks",
                column: "BillParamTypeEnumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeEntityLinks");

            migrationBuilder.DropTable(
                name: "BillParamTypeEnum");
        }
    }
}
