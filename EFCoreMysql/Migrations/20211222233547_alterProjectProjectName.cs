using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreMysql.Migrations
{
    public partial class alterProjectProjectName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "varchar(767)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
