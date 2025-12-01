using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImgEvents_Events_EventId",
                table: "ImgEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgLessons_Lessons_LessonId",
                table: "ImgLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgNewEntity_News_EventId",
                table: "ImgNewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Lessons_LessonId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Visitors_VisitorId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgLessons",
                table: "ImgLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgEvents",
                table: "ImgEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "New");

            migrationBuilder.RenameTable(
                name: "ImgLessons",
                newName: "ImgLesson");

            migrationBuilder.RenameTable(
                name: "ImgEvents",
                newName: "ImgEvent");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_VisitorId",
                table: "Review",
                newName: "IX_Review_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_LessonId",
                table: "Review",
                newName: "IX_Review_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgLessons_LessonId",
                table: "ImgLesson",
                newName: "IX_ImgLesson_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgEvents_EventId",
                table: "ImgEvent",
                newName: "IX_ImgEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_New",
                table: "New",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgLesson",
                table: "ImgLesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgEvent",
                table: "ImgEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImgEvent_Event_EventId",
                table: "ImgEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImgLesson_Lessons_LessonId",
                table: "ImgLesson",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImgNewEntity_New_EventId",
                table: "ImgNewEntity",
                column: "EventId",
                principalTable: "New",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ImgEvent_Event_EventId",
                table: "ImgEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgLesson_Lessons_LessonId",
                table: "ImgLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_ImgNewEntity_New_EventId",
                table: "ImgNewEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Lessons_LessonId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Visitors_VisitorId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_New",
                table: "New");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgLesson",
                table: "ImgLesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImgEvent",
                table: "ImgEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "New",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "ImgLesson",
                newName: "ImgLessons");

            migrationBuilder.RenameTable(
                name: "ImgEvent",
                newName: "ImgEvents");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Review_VisitorId",
                table: "Reviews",
                newName: "IX_Reviews_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_LessonId",
                table: "Reviews",
                newName: "IX_Reviews_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgLesson_LessonId",
                table: "ImgLessons",
                newName: "IX_ImgLessons_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_ImgEvent_EventId",
                table: "ImgEvents",
                newName: "IX_ImgEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgLessons",
                table: "ImgLessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImgEvents",
                table: "ImgEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImgEvents_Events_EventId",
                table: "ImgEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImgLessons_Lessons_LessonId",
                table: "ImgLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImgNewEntity_News_EventId",
                table: "ImgNewEntity",
                column: "EventId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Lessons_LessonId",
                table: "Reviews",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Visitors_VisitorId",
                table: "Reviews",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
