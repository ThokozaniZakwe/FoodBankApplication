using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBankApplication.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Make_HighSchoolGrade_Municipality_Virtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HighSchoolGradeId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "HighSchoolGradeId",
                table: "Candidates");
        }
    }
}
