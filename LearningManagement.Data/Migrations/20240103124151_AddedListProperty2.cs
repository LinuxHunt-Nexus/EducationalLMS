using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedListProperty2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamPassYear",
                table: "InstitutionTeacher",
                newName: "ExamminationPassYear");

            migrationBuilder.RenameColumn(
                name: "ExamPassResult",
                table: "InstitutionTeacher",
                newName: "DegreePassResult");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEGMo45sRouCEGVVV96uYbNRvzC13oqKJvjHoQfyiVODOZuNxuu9/Bu7CAmmC/QWbBg==", "c6ed98d4-0998-4703-8ae4-bcfa606104b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamminationPassYear",
                table: "InstitutionTeacher",
                newName: "ExamPassYear");

            migrationBuilder.RenameColumn(
                name: "DegreePassResult",
                table: "InstitutionTeacher",
                newName: "ExamPassResult");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAELaqjVpFMuge7Rmp/CokhG1gkwm2ylv/A9HBqVSIFggxYttpfKDe80TkUZjbXQU2KQ==", "67ae40c8-8c51-48af-8425-412910a45a2f" });
        }
    }
}
