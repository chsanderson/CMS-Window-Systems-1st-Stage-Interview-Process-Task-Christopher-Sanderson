using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS_Window_Systems_Christopher_Sanderson.Migrations
{
    public partial class Databaselong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "JobKeyID",
                table: "QRTable",
                type: "bigint",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<long>(
                name: "JobKeyID",
                table: "Production",
                type: "bigint",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<long>(
                name: "JobKeyID",
                table: "Heading",
                type: "bigint",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JobKeyID",
                table: "QRTable",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<int>(
                name: "JobKeyID",
                table: "Production",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<int>(
                name: "JobKeyID",
                table: "Heading",
                type: "int",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 8);
        }
    }
}
