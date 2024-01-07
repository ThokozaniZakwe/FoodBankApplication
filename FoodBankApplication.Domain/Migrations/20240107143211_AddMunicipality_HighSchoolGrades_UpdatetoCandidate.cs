using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddMunicipality_HighSchoolGrades_UpdatetoCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumbers",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HighSchoolGradeId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HighShcoolGradeId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HighSchoolGrade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighSchoolGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_HighSchoolGradeId",
                table: "Candidates",
                column: "HighSchoolGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_MunicipalityId",
                table: "Candidates",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_HighSchoolGrade_HighSchoolGradeId",
                table: "Candidates",
                column: "HighSchoolGradeId",
                principalTable: "HighSchoolGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Municipality_MunicipalityId",
                table: "Candidates",
                column: "MunicipalityId",
                principalTable: "Municipality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_HighSchoolGrade_HighSchoolGradeId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Municipality_MunicipalityId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "HighSchoolGrade");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_HighSchoolGradeId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_MunicipalityId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ContactNumbers",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "HighSchoolGradeId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "HighShcoolGradeId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Candidates");
        }
    }
}
