using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesEvent_Events_EventEntityId",
                table: "ImagesEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLesson_Lessons_LessonEntityId",
                table: "ImagesLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesNews_News_NewsEntityId",
                table: "ImagesNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesNews",
                table: "ImagesNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesLesson",
                table: "ImagesLesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesEvent",
                table: "ImagesEvent");

            migrationBuilder.RenameTable(
                name: "ImagesNews",
                newName: "ImgNewsEntity");

            migrationBuilder.RenameTable(
                name: "ImagesLesson",
                newName: "ImgLessonEntity");

            migrationBuilder.RenameTable(
                name: "ImagesEvent",
                newName: "ImgEventEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesNews_NewsEntityId",
                table: "ImgNewsEntity",
                newName: "IX_ImgNewsEntity_NewsEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesLesson_LessonEntityId",
                table: "ImgLessonEntity",
                newName: "IX_ImgLessonEntity_LessonEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesEvent_EventEntityId",
                table: "ImgEventEntity",
                newName: "IX_ImgEventEntity_EventEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgNewsEntity",
                table: "ImgNewsEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgLessonEntity",
                table: "ImgLessonEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgEventEntity",
                table: "ImgEventEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImgEventEntity_Events_EventEntityId",
                table: "ImgEventEntity",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImgLessonEntity_Lessons_LessonEntityId",
                table: "ImgLessonEntity",
                column: "LessonEntityId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImgNewsEntity_News_NewsEntityId",
                table: "ImgNewsEntity",
                column: "NewsEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImgEventEntity_Events_EventEntityId",
                table: "ImgEventEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgLessonEntity_Lessons_LessonEntityId",
                table: "ImgLessonEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgNewsEntity_News_NewsEntityId",
                table: "ImgNewsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgNewsEntity",
                table: "ImgNewsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgLessonEntity",
                table: "ImgLessonEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgEventEntity",
                table: "ImgEventEntity");

            migrationBuilder.RenameTable(
                name: "ImgNewsEntity",
                newName: "ImagesNews");

            migrationBuilder.RenameTable(
                name: "ImgLessonEntity",
                newName: "ImagesLesson");

            migrationBuilder.RenameTable(
                name: "ImgEventEntity",
                newName: "ImagesEvent");

            migrationBuilder.RenameIndex(
                name: "IX_ImgNewsEntity_NewsEntityId",
                table: "ImagesNews",
                newName: "IX_ImagesNews_NewsEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgLessonEntity_LessonEntityId",
                table: "ImagesLesson",
                newName: "IX_ImagesLesson_LessonEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgEventEntity_EventEntityId",
                table: "ImagesEvent",
                newName: "IX_ImagesEvent_EventEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesNews",
                table: "ImagesNews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesLesson",
                table: "ImagesLesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesEvent",
                table: "ImagesEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesEvent_Events_EventEntityId",
                table: "ImagesEvent",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesLesson_Lessons_LessonEntityId",
                table: "ImagesLesson",
                column: "LessonEntityId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesNews_News_NewsEntityId",
                table: "ImagesNews",
                column: "NewsEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
