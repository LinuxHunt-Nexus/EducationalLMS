using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class EducationQualification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EduQualification",
                table: "InstitutionTeacher",
                newName: "EduQualificationString");

            migrationBuilder.CreateTable(
                name: "EduQualification",
                columns: table => new
                {
                    Qulifiation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exparience = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEFPapmAq+QpT7/MdJUD8SbF7s4L6qIGpsnz1cLI+R0DxlrQzfeG9x58EW2Dy9bQlmg==", "24a4bdba-e992-4e5c-8b28-aa85b47f7e89" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduQualification");

            migrationBuilder.RenameColumn(
                name: "EduQualificationString",
                table: "InstitutionTeacher",
                newName: "EduQualification");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHjqEg/7/K1/YQkjfAGMpvIlnrzjvWHr7JQPQ4C+ixNW/5kUodumnkH+/ZTwd8wj3g==", "30fbafc3-d01d-43d4-8804-04d11e4ca914" });
        }
    }
}
