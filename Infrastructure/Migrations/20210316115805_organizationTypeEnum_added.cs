using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class organizationTypeEnum_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationType",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrganizationType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrganizationType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrganizationType",
                value: 4);

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name", "OrganizationType" },
                values: new object[,]
                {
                    { 4, "Рога и копыта", 0 },
                    { 5, "Башкирэнерго", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OrganizationType",
                table: "Organizations");
        }
    }
}
