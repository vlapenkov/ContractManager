using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class billparams_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BillParamTypeEnum",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ценовая категория" },
                    { 2, "Тарифный уровень напряжения" },
                    { 3, "Знак вхождения" },
                    { 4, "Категория мощности" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BillParamTypeEnum",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BillParamTypeEnum",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BillParamTypeEnum",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BillParamTypeEnum",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
