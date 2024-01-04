using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrganizationColumnOnInstitutionTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearsOfExperience",
                table: "InstitutionTeacher",
                newName: "OrganizationSet");

            migrationBuilder.AddColumn<string>(
                name: "DesignationSet",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormToYearSet",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEEr4FCJHMcmG9bDT951D4+Yo0lEJzmtmxHio0g1TW/JIWPf/ZYcbyf6V9aKPBqrJJA==", "855a84f9-408a-4d67-92bb-da7a8b73fe66" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignationSet",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "FormToYearSet",
                table: "InstitutionTeacher");

            migrationBuilder.RenameColumn(
                name: "OrganizationSet",
                table: "InstitutionTeacher",
                newName: "YearsOfExperience");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEDkEz0rd9xaa+IwNJQOT278ApCiRQ2UHFHo14mnOhBM+6xSRWm8LcptzEjXW0DQabw==", "ab6ee8ea-59fb-4a96-b00f-8967c965733c" });
        }
    }
}
