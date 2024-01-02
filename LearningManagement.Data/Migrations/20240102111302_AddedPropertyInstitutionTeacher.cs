using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyInstitutionTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EduQualification",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhone",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GraduationYear",
                table: "InstitutionTeacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasHealthInsurance",
                table: "InstitutionTeacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InstitutionTeacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "InstitutionTeacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MedicalConditions",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NID",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousInstitutions",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subjects",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherAddress",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TeachingRating",
                table: "InstitutionTeacher",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearsOfExperience",
                table: "InstitutionTeacher",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHjqEg/7/K1/YQkjfAGMpvIlnrzjvWHr7JQPQ4C+ixNW/5kUodumnkH+/ZTwd8wj3g==", "30fbafc3-d01d-43d4-8804-04d11e4ca914" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EduQualification",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhone",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "HasHealthInsurance",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "MedicalConditions",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "NID",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "PreviousInstitutions",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "Subjects",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "TeacherAddress",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "TeachingRating",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "University",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "InstitutionTeacher");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHeSnLP3cjb1R5iMhbE1fi+s03fH6Gd5JT5lA4keb3GSj7eg3JIVjLe1YvO0oCYlHw==", "ddaf2008-4074-46e7-b070-f1893114753d" });
        }
    }
}
