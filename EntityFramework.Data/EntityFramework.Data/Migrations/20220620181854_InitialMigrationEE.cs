using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Data.Migrations
{
    public partial class InitialMigrationEE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEducations",
                table: "EmployeeEducations");

            migrationBuilder.RenameTable(
                name: "EmployeeEducations",
                newName: "EmployeeEducation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEducation",
                table: "EmployeeEducation",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEducation",
                table: "EmployeeEducation");

            migrationBuilder.RenameTable(
                name: "EmployeeEducation",
                newName: "EmployeeEducations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEducations",
                table: "EmployeeEducations",
                column: "ID");
        }
    }
}
