using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace paymybill.web.app.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillCompanies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillCompanies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BillTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MobileNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredBills",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillNick = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<string>(maxLength: 11, nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    Consumersid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredBills", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegisteredBills_BillCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BillCompanies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredBills_Consumers_Consumersid",
                        column: x => x.Consumersid,
                        principalTable: "Consumers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisteredBills_BillTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BillTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredBills_CompanyId",
                table: "RegisteredBills",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredBills_Consumersid",
                table: "RegisteredBills",
                column: "Consumersid");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredBills_TypeId",
                table: "RegisteredBills",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredBills");

            migrationBuilder.DropTable(
                name: "BillCompanies");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "BillTypes");
        }
    }
}
