using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addRowsToEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prefix",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Skype",
                table: "Employees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "Employees");
        }
    }
}
