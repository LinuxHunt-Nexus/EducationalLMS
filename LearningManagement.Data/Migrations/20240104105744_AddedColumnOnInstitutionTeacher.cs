using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnOnInstitutionTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduQualification");

            migrationBuilder.DropColumn(
                name: "Subjects",
                table: "InstitutionTeacher");

            migrationBuilder.AddColumn<string>(
                name: "InstitutionSet",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEDkEz0rd9xaa+IwNJQOT278ApCiRQ2UHFHo14mnOhBM+6xSRWm8LcptzEjXW0DQabw==", "ab6ee8ea-59fb-4a96-b00f-8967c965733c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstitutionSet",
                table: "InstitutionTeacher");

            migrationBuilder.AddColumn<string>(
                name: "Subjects",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EduQualification",
                columns: table => new
                {
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exparience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qulifiation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEGMo45sRouCEGVVV96uYbNRvzC13oqKJvjHoQfyiVODOZuNxuu9/Bu7CAmmC/QWbBg==", "c6ed98d4-0998-4703-8ae4-bcfa606104b2" });
        }
    }
}
