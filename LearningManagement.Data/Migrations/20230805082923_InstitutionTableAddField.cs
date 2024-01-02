using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class InstitutionTableAddField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InstitutionLogoUrl",
                table: "Institution",
                newName: "InstitutionLogoName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Institution",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Institution");

            migrationBuilder.RenameColumn(
                name: "InstitutionLogoName",
                table: "Institution",
                newName: "InstitutionLogoUrl");
        }
    }
}
