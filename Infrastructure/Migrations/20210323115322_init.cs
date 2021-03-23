using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillPointRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ContractType = table.Column<int>(type: "integer", nullable: false),
                    ContractKind = table.Column<int>(type: "integer", nullable: false),
                    OrganizationTypeSide1 = table.Column<int>(type: "integer", nullable: false),
                    OrganizationTypeSide2 = table.Column<int>(type: "integer", nullable: false),
                    EntrySign = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPointRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DocumentNumber = table.Column<string>(type: "text", nullable: false),
                    SignDate = table.Column<DateTime>(type: "Date", nullable: false),
                    SActionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EActionDate = table.Column<DateTime>(type: "Date", nullable: true),
                    DocumentType = table.Column<int>(type: "integer", nullable: false),
                    ContractKind = table.Column<int>(type: "integer", nullable: true),
                    ContractDocumentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDocument_ContractDocument_ContractDocumentId",
                        column: x => x.ContractDocumentId,
                        principalTable: "ContractDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLinkObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLinkObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShortName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LongName = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    AcsId = table.Column<int>(type: "integer", nullable: true),
                    OrganizationType = table.Column<int>(type: "integer", nullable: false),
                    ParentOrganizationId = table.Column<int>(type: "integer", nullable: true),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RfSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CodeAts = table.Column<string>(type: "text", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillSideToBillPoints",
                columns: table => new
                {
                    EnergyLinkObjectId = table.Column<int>(type: "integer", nullable: false),
                    BillPointId = table.Column<int>(type: "integer", nullable: false),
                    SDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EDate = table.Column<DateTime>(type: "Date", nullable: true),
                    TypeSide = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnergyLinkObjectId = table.Column<int>(type: "integer", nullable: false),
                    BillPointId = table.Column<int>(type: "integer", nullable: false),
                    SDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EDate = table.Column<DateTime>(type: "Date", nullable: true)
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
                        name: "FK_EnergyLinkObjectToBillPoint_EnergyLinkObjects_EnergyLinkObj~",
                        column: x => x.EnergyLinkObjectId,
                        principalTable: "EnergyLinkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParticipantType = table.Column<int>(type: "integer", nullable: false),
                    OrganizationId = table.Column<int>(type: "integer", nullable: true),
                    ContractId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractParticipants_ContractDocument_ContractId",
                        column: x => x.ContractId,
                        principalTable: "ContractDocument",
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
                name: "BillObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContractId = table.Column<int>(type: "integer", nullable: false),
                    RfSubjectId = table.Column<int>(type: "integer", nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillObjects_ContractDocument_ContractId",
                        column: x => x.ContractId,
                        principalTable: "ContractDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillObjects_RfSubjects_RfSubjectId",
                        column: x => x.RfSubjectId,
                        principalTable: "RfSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillParams",
                columns: table => new
                {
                    EnergyLinkObjectToBillPointId = table.Column<int>(type: "integer", nullable: false),
                    BillParamType = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillParams", x => new { x.EnergyLinkObjectToBillPointId, x.BillParamType });
                    table.ForeignKey(
                        name: "FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBi~",
                        column: x => x.EnergyLinkObjectToBillPointId,
                        principalTable: "EnergyLinkObjectToBillPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillObjectToEnergyLinkObjects",
                columns: table => new
                {
                    EnergyLinkObjectId = table.Column<int>(type: "integer", nullable: false),
                    BillObjectId = table.Column<int>(type: "integer", nullable: false),
                    SDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EDate = table.Column<DateTime>(type: "Date", nullable: true)
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
                        name: "FK_BillObjectToEnergyLinkObjects_EnergyLinkObjects_EnergyLinkO~",
                        column: x => x.EnergyLinkObjectId,
                        principalTable: "EnergyLinkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillPoints",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("b8d40d2b-b9f2-463f-a3e8-467dcfbb48ea"), "bp1" },
                    { 2, new Guid("2ee047a6-d87c-44b7-9e0e-f89bd526b1c3"), "bp2" },
                    { 3, new Guid("235f7a97-ac8d-47c9-bead-528ff21a005f"), "bp3" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AcsId", "Guid", "LongName", "OrganizationType", "ParentOrganizationId", "ShortName" },
                values: new object[,]
                {
                    { 1, null, new Guid("1b55b6f5-0e97-4764-8b33-65b80860b63f"), "ТНЭ", 1, null, "ТНЭ" },
                    { 2, null, new Guid("f891250d-0d9f-43cf-b5fd-47e8c027eeee"), "КТК", 4, null, "КТК" },
                    { 3, null, new Guid("85f9fbb7-e680-46b6-8c91-ce2c35dd4193"), "Дружба", 4, null, "Дружба" },
                    { 4, null, new Guid("043210b2-d3a0-4fc2-b505-735558c48a07"), "Рога и копыта", 0, null, "Рога и копыта" },
                    { 5, null, new Guid("f97736b3-fc4d-466c-8c93-22c4c020a5fc"), "Башкирэнерго", 3, null, "Башкирэнерго" }
                });

            migrationBuilder.InsertData(
                table: "RfSubjects",
                columns: new[] { "Id", "Code", "CodeAts", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, "30", "12", new Guid("d8162092-2702-4ae3-a4f3-fbd1a85b6069"), "Астраханская область" },
                    { 2, "26", "07", new Guid("99b12c1a-5df8-4f13-96b9-1a46f74ac7bc"), "Ставропольский край" },
                    { 3, "23", "03", new Guid("8164c992-8c0b-42cb-bbb7-3b46461146cc"), "Краснодарский край" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillObjects_ContractId",
                table: "BillObjects",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_BillObjects_Guid",
                table: "BillObjects",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillObjects_RfSubjectId",
                table: "BillObjects",
                column: "RfSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BillObjectToEnergyLinkObjects_EnergyLinkObjectId",
                table: "BillObjectToEnergyLinkObjects",
                column: "EnergyLinkObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPoints_Guid",
                table: "BillPoints",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillSideToBillPoints_BillPointId",
                table: "BillSideToBillPoints",
                column: "BillPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocument_ContractDocumentId",
                table: "ContractDocument",
                column: "ContractDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDocument_Guid",
                table: "ContractDocument",
                column: "Guid",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Guid",
                table: "Organizations",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentOrganizationId",
                table: "Organizations",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RfSubjects_Guid",
                table: "RfSubjects",
                column: "Guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillObjectToEnergyLinkObjects");

            migrationBuilder.DropTable(
                name: "BillParams");

            migrationBuilder.DropTable(
                name: "BillPointRules");

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
                name: "ContractDocument");

            migrationBuilder.DropTable(
                name: "RfSubjects");

            migrationBuilder.DropTable(
                name: "BillPoints");

            migrationBuilder.DropTable(
                name: "EnergyLinkObjects");
        }
    }
}
