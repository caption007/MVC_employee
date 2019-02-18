using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Migrations
{
    public partial class Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departmenty",
                table: "Employee",
                newName: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employee",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Employee",
                newName: "Departmenty");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
