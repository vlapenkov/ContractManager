using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractKinds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLinkObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLinkObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractKindId = table.Column<int>(type: "int", nullable: true),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractKinds_ContractKindId",
                        column: x => x.ContractKindId,
                        principalTable: "ContractKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillObjects_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantTypeId = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractParticipants_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractParticipants_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractParticipants_ParticipantTypes_ParticipantTypeId",
                        column: x => x.ParticipantTypeId,
                        principalTable: "ParticipantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillObjectToEnergyLinkObjects",
                columns: table => new
                {
                    EnergyLinkObjectId = table.Column<int>(type: "int", nullable: false),
                    BillObjectId = table.Column<int>(type: "int", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillObjectToEnergyLinkObjects", x => new { x.BillObjectId, x.EnergyLinkObjectId, x.SDate });
                    table.ForeignKey(
                        name: "FK_BillObjectToEnergyLinkObjects_BillObjects_BillObjectId",
                        column: x => x.BillObjectId,
                        principalTable: "BillObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillObjectToEnergyLinkObjects_EnergyLinkObjects_EnergyLinkObjectId",
                        column: x => x.EnergyLinkObjectId,
                        principalTable: "EnergyLinkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContractKinds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Договор энергоснабжения" },
                    { 2, "Договор купили-продажи" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ТНЭ" },
                    { 2, "КТК" },
                    { 3, "Дружба" }
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
                name: "IX_BillObjects_ContractId",
                table: "BillObjects",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_BillObjectToEnergyLinkObjects_EnergyLinkObjectId",
                table: "BillObjectToEnergyLinkObjects",
                column: "EnergyLinkObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_ContractId",
                table: "ContractParticipants",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_OrganizationId",
                table: "ContractParticipants",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_ParticipantTypeId",
                table: "ContractParticipants",
                column: "ParticipantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractKindId",
                table: "Contracts",
                column: "ContractKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillObjectToEnergyLinkObjects");

            migrationBuilder.DropTable(
                name: "ContractParticipants");

            migrationBuilder.DropTable(
                name: "BillObjects");

            migrationBuilder.DropTable(
                name: "EnergyLinkObjects");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "ParticipantTypes");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "ContractKinds");
        }
    }
}
