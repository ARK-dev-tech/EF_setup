using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_setup.Migrations
{
    /// <inheritdoc />
    public partial class FixGradeIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grade_GradeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "grade_id",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Students_grade_id",
                table: "Students",
                column: "grade_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grade_grade_id",
                table: "Students",
                column: "grade_id",
                principalTable: "Grade",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Grade_grade_id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_grade_id",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "grade_id",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Grade_GradeId",
                table: "Students",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
