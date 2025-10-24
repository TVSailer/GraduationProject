using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Lessons_LessonEntityId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_LessonEntityId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "LessonEntityId",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Review",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisitorId",
                table: "Review",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_LessonId",
                table: "Review",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_VisitorId",
                table: "Review",
                column: "VisitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Lessons_LessonId",
                table: "Review",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Visitors_VisitorId",
                table: "Review",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Lessons_LessonId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Visitors_VisitorId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_LessonId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_VisitorId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "LessonEntityId",
                table: "Review",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_LessonEntityId",
                table: "Review",
                column: "LessonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Lessons_LessonEntityId",
                table: "Review",
                column: "LessonEntityId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }
    }
}
