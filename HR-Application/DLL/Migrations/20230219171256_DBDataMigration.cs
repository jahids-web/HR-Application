using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class DBDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MobileNo",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Employees",
                type: "nvarchar(12)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
