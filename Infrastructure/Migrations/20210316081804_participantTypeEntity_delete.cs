using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class participantTypeEntity_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractParticipants_ParticipantTypes_ParticipantTypeId",
                table: "ContractParticipants");

            migrationBuilder.DropTable(
                name: "BillParamTypeEnum");

            migrationBuilder.DropTable(
                name: "ParticipantTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContractParticipants_ParticipantTypeId",
                table: "ContractParticipants");

            migrationBuilder.DropColumn(
                name: "ParticipantTypeId",
                table: "ContractParticipants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantTypeId",
                table: "ContractParticipants",
                type: "int",
                nullable: true);

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
                name: "ParticipantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantTypes", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "ParticipantTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Продавец электроэнергии" },
                    { 2, "Покупатель электроэнергии" },
                    { 3, "Население" },
                    { 4, "Организация оказывающая услуги населению" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_ParticipantTypeId",
                table: "ContractParticipants",
                column: "ParticipantTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractParticipants_ParticipantTypes_ParticipantTypeId",
                table: "ContractParticipants",
                column: "ParticipantTypeId",
                principalTable: "ParticipantTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
