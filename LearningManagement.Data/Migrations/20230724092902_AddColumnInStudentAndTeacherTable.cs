using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInStudentAndTeacherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "InstitutionTeacher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "InstitutionTeacher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "InstitutionTeacher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "InstitutionTeacher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "InstitutionTeacher",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "InstitutionTeacher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "InstitutionTeacher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "InstitutionTeacher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "InstitutionStudent",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdmissionNumber",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "InstitutionStudent",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "InstitutionStudent",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "InstitutionStudent",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "InstitutionStudent",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "InstitutionStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "InstitutionTeacher");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "AdmissionNumber",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "InstitutionStudent");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "InstitutionStudent");

        }
    }
}
