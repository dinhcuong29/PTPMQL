using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demomvc.Migrations
{
    /// <inheritdoc />
    public partial class fix_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Students",
                newName: "Name");
        }
    }
}
