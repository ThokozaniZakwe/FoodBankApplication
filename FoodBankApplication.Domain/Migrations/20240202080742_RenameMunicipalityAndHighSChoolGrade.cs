using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RenameMunicipalityAndHighSChoolGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_HighSchoolGrade_HighSchoolGradeId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Municipality_MunicipalityId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HighSchoolGrade",
                table: "HighSchoolGrade");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.RenameTable(
                name: "HighSchoolGrade",
                newName: "HighSchoolGrades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HighSchoolGrades",
                table: "HighSchoolGrades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_HighSchoolGrades_HighSchoolGradeId",
                table: "Candidates",
                column: "HighSchoolGradeId",
                principalTable: "HighSchoolGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Municipalities_MunicipalityId",
                table: "Candidates",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_HighSchoolGrades_HighSchoolGradeId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Municipalities_MunicipalityId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HighSchoolGrades",
                table: "HighSchoolGrades");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.RenameTable(
                name: "HighSchoolGrades",
                newName: "HighSchoolGrade");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HighSchoolGrade",
                table: "HighSchoolGrade",
                column: "Id");

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
    }
}
