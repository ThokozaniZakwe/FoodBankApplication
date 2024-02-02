using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class HighSchoolId_Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighShcoolGradeId",
                table: "Candidates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HighShcoolGradeId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
