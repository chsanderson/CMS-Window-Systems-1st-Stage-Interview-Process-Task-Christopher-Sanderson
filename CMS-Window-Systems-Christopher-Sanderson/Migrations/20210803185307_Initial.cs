using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS_Window_Systems_Christopher_Sanderson.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heading",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobKeyID = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    DateInProduction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heading", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobKeyID = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    ItemKeyID = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QRTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobKeyID = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    ItemKeyID = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    ScanDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heading");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "QRTable");
        }
    }
}
