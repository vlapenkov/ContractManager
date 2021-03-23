using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class billpointtometerpoint_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillPointToMeterPoint",
                columns: table => new
                {
                    BillPointId = table.Column<int>(type: "integer", nullable: false),
                    MeterPointId = table.Column<int>(type: "integer", nullable: false),
                    SDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EDate = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPointToMeterPoint", x => new { x.BillPointId, x.MeterPointId, x.SDate });
                    table.ForeignKey(
                        name: "FK_BillPointToMeterPoint_BillPoints_BillPointId",
                        column: x => x.BillPointId,
                        principalTable: "BillPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillPointToMeterPoint_MeterPoint_MeterPointId",
                        column: x => x.MeterPointId,
                        principalTable: "MeterPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("954b7565-20ff-4321-9e8c-8e890953598a"));

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("ed2e5591-c148-4688-bd7c-f4250fa93165"));

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("96351e37-a7f4-4734-b77f-47d55f294090"));

            migrationBuilder.InsertData(
                table: "MeterPoint",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("1245249a-4b74-48fd-b635-8c10f2660b55"), "ТИ-11" },
                    { 2, new Guid("f1156e79-9343-4598-95c9-57bb6e0b4dbd"), "ТИ-12" },
                    { 3, new Guid("4fe44c30-8ead-421a-8689-9c7be542b38e"), "ТИ-21" },
                    { 4, new Guid("0125044e-87d2-4e46-befe-c29ec4925608"), "ТИ-31" }
                });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("76a1020f-a289-4950-858d-8cd08fbe8a27"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("fd177c31-2e33-489c-9e94-c109e5817396"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("b576d00e-f058-430c-92d2-4f7bdfc78956"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("c9e54849-c6f7-4ce8-adb1-7adfeaa2fd8d"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("0b7e4010-f5e0-4736-aa61-007d3bf52cb1"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("3644330d-dc56-4a37-a23d-a8528132a41b"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("6dc9ea60-5b2c-4287-a65f-4f8d3ebaa144"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("9b252216-0b32-4cf9-beca-da333de98e6c"));

            migrationBuilder.InsertData(
                table: "BillPointToMeterPoint",
                columns: new[] { "BillPointId", "MeterPointId", "SDate", "EDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 1, 2, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), null },
                    { 2, 3, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 4, new DateTime(2021, 3, 13, 0, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillPointToMeterPoint_MeterPointId",
                table: "BillPointToMeterPoint",
                column: "MeterPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillPointToMeterPoint");

            migrationBuilder.DropTable(
                name: "MeterPoint");

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("b8d40d2b-b9f2-463f-a3e8-467dcfbb48ea"));

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("2ee047a6-d87c-44b7-9e0e-f89bd526b1c3"));

            migrationBuilder.UpdateData(
                table: "BillPoints",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("235f7a97-ac8d-47c9-bead-528ff21a005f"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("1b55b6f5-0e97-4764-8b33-65b80860b63f"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("f891250d-0d9f-43cf-b5fd-47e8c027eeee"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("85f9fbb7-e680-46b6-8c91-ce2c35dd4193"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Guid",
                value: new Guid("043210b2-d3a0-4fc2-b505-735558c48a07"));

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Guid",
                value: new Guid("f97736b3-fc4d-466c-8c93-22c4c020a5fc"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Guid",
                value: new Guid("d8162092-2702-4ae3-a4f3-fbd1a85b6069"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Guid",
                value: new Guid("99b12c1a-5df8-4f13-96b9-1a46f74ac7bc"));

            migrationBuilder.UpdateData(
                table: "RfSubjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Guid",
                value: new Guid("8164c992-8c0b-42cb-bbb7-3b46461146cc"));
        }
    }
}
