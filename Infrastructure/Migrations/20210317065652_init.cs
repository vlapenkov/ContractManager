using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TnePointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractKind = table.Column<int>(type: "int", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
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
                name: "BillSideToBillPoints",
                columns: table => new
                {
                    EnergyLinkObjectId = table.Column<int>(type: "int", nullable: false),
                    BillPointId = table.Column<int>(type: "int", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeSide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSideToBillPoints", x => new { x.EnergyLinkObjectId, x.BillPointId, x.SDate });
                    table.ForeignKey(
                        name: "FK_BillSideToBillPoints_BillPoints_BillPointId",
                        column: x => x.BillPointId,
                        principalTable: "BillPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillSideToBillPoints_EnergyLinkObjects_EnergyLinkObjectId",
                        column: x => x.EnergyLinkObjectId,
                        principalTable: "EnergyLinkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "ContractParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantType = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "BillParams",
                columns: table => new
                {
                    EnergyLinkObjectToBillPointId = table.Column<int>(type: "int", nullable: false),
                    BillParamType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillParams", x => new { x.EnergyLinkObjectToBillPointId, x.BillParamType });
                    table.ForeignKey(
                        name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId",
                        column: x => x.EnergyLinkObjectToBillPointId,
                        principalTable: "EnergyLinkObjectToBillPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillPoints",
                columns: new[] { "Id", "Name", "TnePointId" },
                values: new object[,]
                {
                    { 1, "bp1", 1 },
                    { 2, "bp1", 2 },
                    { 3, "bp1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name", "OrganizationType" },
                values: new object[,]
                {
                    { 1, "ТНЭ", 1 },
                    { 2, "КТК", 4 },
                    { 3, "Дружба", 4 },
                    { 4, "Рога и копыта", 0 },
                    { 5, "Башкирэнерго", 3 }
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
                name: "IX_BillSideToBillPoints_BillPointId",
                table: "BillSideToBillPoints",
                column: "BillPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_ContractId",
                table: "ContractParticipants",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractParticipants_OrganizationId",
                table: "ContractParticipants",
                column: "OrganizationId");

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
                name: "BillObjectToEnergyLinkObjects");

            migrationBuilder.DropTable(
                name: "BillParams");

            migrationBuilder.DropTable(
                name: "BillSideToBillPoints");

            migrationBuilder.DropTable(
                name: "ContractParticipants");

            migrationBuilder.DropTable(
                name: "BillObjects");

            migrationBuilder.DropTable(
                name: "EnergyLinkObjectToBillPoint");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "BillPoints");

            migrationBuilder.DropTable(
                name: "EnergyLinkObjects");
        }
    }
}
