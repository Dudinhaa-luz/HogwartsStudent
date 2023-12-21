using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogwartsStudentsCrud.Migrations
{
    /// <inheritdoc />
    public partial class StudentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bogeyman",
                table: "Students",
                newName: "Boggart");

            migrationBuilder.AlterColumn<string>(
                name: "EnrollmentYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Boggart",
                table: "Students",
                newName: "Bogeyman");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentYear",
                table: "Students",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
