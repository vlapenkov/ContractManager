using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billparamtypeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillParams_BillParamTypes_BillParamTypeId",
                table: "BillParams");

            migrationBuilder.DropTable(
                name: "BillParamTypes");

            migrationBuilder.DropIndex(
                name: "IX_BillParams_BillParamTypeId",
                table: "BillParams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_BillParams_BillParamTypes_BillParamTypeId",
                table: "BillParams",
                column: "BillParamTypeId",
                principalTable: "BillParamTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
