using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedListProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EduQualificationString",
                table: "InstitutionTeacher",
                newName: "ExamPassYear");

            migrationBuilder.AddColumn<string>(
                name: "EducationQualification",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamPassResult",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAELaqjVpFMuge7Rmp/CokhG1gkwm2ylv/A9HBqVSIFggxYttpfKDe80TkUZjbXQU2KQ==", "67ae40c8-8c51-48af-8425-412910a45a2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationQualification",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "ExamPassResult",
                table: "InstitutionTeacher");

            migrationBuilder.RenameColumn(
                name: "ExamPassYear",
                table: "InstitutionTeacher",
                newName: "EduQualificationString");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEFPapmAq+QpT7/MdJUD8SbF7s4L6qIGpsnz1cLI+R0DxlrQzfeG9x58EW2Dy9bQlmg==", "24a4bdba-e992-4e5c-8b28-aa85b47f7e89" });
        }
    }
}
