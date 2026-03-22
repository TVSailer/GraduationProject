using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDBEventModel5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LessonId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_LessonId",
                table: "Image",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Lessons_LessonId",
                table: "Image",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Lessons_LessonId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_LessonId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Image");
        }
    }
}
