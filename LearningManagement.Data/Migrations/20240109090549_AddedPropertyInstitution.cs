using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accreditation",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdmissionProcedure",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Affiliation",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CampusFacilities",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedDate",
                table: "Institution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Founder",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MissionStatement",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalEmail",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalName",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalPhone",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaLinks",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalCourses",
                table: "Institution",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalStudents",
                table: "Institution",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTeachers",
                table: "Institution",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VisionStatement",
                table: "Institution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHCS+3SdqzaOH0xUo2UYf/hSwc1nqBt1CaJ1MwgJLamHi2JCh/qBd5q0z0hf9D2MhQ==", "2e251cec-94a5-4ddc-a4c4-a74210914312" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accreditation",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "AdmissionProcedure",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "Affiliation",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "CampusFacilities",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "FoundedDate",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "Founder",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "MissionStatement",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "PrincipalEmail",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "PrincipalName",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "PrincipalPhone",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "SocialMediaLinks",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "TotalCourses",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "TotalStudents",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "TotalTeachers",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "VisionStatement",
                table: "Institution");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEEr4FCJHMcmG9bDT951D4+Yo0lEJzmtmxHio0g1TW/JIWPf/ZYcbyf6V9aKPBqrJJA==", "855a84f9-408a-4d67-92bb-da7a8b73fe66" });
        }
    }
}
