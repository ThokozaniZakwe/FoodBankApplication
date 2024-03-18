using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class LinkProvinceToCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ProvinceId",
                table: "Candidates",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Provinces_ProvinceId",
                table: "Candidates",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Provinces_ProvinceId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ProvinceId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Candidates");
        }
    }
}
