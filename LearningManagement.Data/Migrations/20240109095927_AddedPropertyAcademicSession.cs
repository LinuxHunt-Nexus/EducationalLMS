using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyAcademicSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicSessionId",
                table: "InstitutionCourse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcademicSessionId",
                table: "InstitutionClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcademicCalendar",
                table: "AcademicSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Achievements",
                table: "AcademicSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageStudentAttendance",
                table: "AcademicSession",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageStudentPerformance",
                table: "AcademicSession",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChallengesFaced",
                table: "AcademicSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FutureGoals",
                table: "AcademicSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AcademicSession",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SessionDirector",
                table: "AcademicSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SessionTime",
                table: "AcademicSession",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalStudentsEnrolled",
                table: "AcademicSession",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEFbOlivwWvpRmqNdRbSaG4Cj/pB+Ve50l/jArefeSKN01KjGcyqA4DI5Ow3TJvHvhg==", "dff1dd3b-5bc1-4f10-a02c-1da256f74b10" });

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionCourse_AcademicSessionId",
                table: "InstitutionCourse",
                column: "AcademicSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionClass_AcademicSessionId",
                table: "InstitutionClass",
                column: "AcademicSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionClass_AcademicSession_AcademicSessionId",
                table: "InstitutionClass",
                column: "AcademicSessionId",
                principalTable: "AcademicSession",
                principalColumn: "AcademicSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstitutionCourse_AcademicSession_AcademicSessionId",
                table: "InstitutionCourse",
                column: "AcademicSessionId",
                principalTable: "AcademicSession",
                principalColumn: "AcademicSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionClass_AcademicSession_AcademicSessionId",
                table: "InstitutionClass");

            migrationBuilder.DropForeignKey(
                name: "FK_InstitutionCourse_AcademicSession_AcademicSessionId",
                table: "InstitutionCourse");

            migrationBuilder.DropIndex(
                name: "IX_InstitutionCourse_AcademicSessionId",
                table: "InstitutionCourse");

            migrationBuilder.DropIndex(
                name: "IX_InstitutionClass_AcademicSessionId",
                table: "InstitutionClass");

            migrationBuilder.DropColumn(
                name: "AcademicSessionId",
                table: "InstitutionCourse");

            migrationBuilder.DropColumn(
                name: "AcademicSessionId",
                table: "InstitutionClass");

            migrationBuilder.DropColumn(
                name: "AcademicCalendar",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "Achievements",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "AverageStudentAttendance",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "AverageStudentPerformance",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "ChallengesFaced",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "FutureGoals",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "SessionDirector",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "SessionTime",
                table: "AcademicSession");

            migrationBuilder.DropColumn(
                name: "TotalStudentsEnrolled",
                table: "AcademicSession");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A0456563-F978-4135-B563-97F23EA02FDA",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHCS+3SdqzaOH0xUo2UYf/hSwc1nqBt1CaJ1MwgJLamHi2JCh/qBd5q0z0hf9D2MhQ==", "2e251cec-94a5-4ddc-a4c4-a74210914312" });
        }
    }
}
