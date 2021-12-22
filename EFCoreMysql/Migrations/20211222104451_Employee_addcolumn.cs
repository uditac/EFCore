using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMysql.Migrations
{
    public partial class Employee_addcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_FirstName",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Lastname",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "Employees",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName",
                table: "Employees",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Lastname",
                table: "Employees",
                column: "Lastname");
        }
    }
}
