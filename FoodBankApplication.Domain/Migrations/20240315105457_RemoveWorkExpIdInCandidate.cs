using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWorkExpIdInCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Candidates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkExperienceId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
