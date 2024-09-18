using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demomvc.Migrations
{
    /// <inheritdoc />
    public partial class Employee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sđt",
                table: "Persons",
                newName: "Sđt");

            migrationBuilder.AlterColumn<string>(
                name: "Sđt",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployerID = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "Sđt",
                table: "Persons",
                newName: "sđt");

            migrationBuilder.AlterColumn<int>(
                name: "sđt",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
