using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DateAttendanceVisitor",
                columns: new[] { "DateAttendanceId", "VisitorId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 3 },
                    { 4, 2 },
                    { 4, 6 },
                    { 5, 4 },
                    { 5, 6 },
                    { 6, 2 },
                    { 6, 4 },
                    { 7, 6 },
                    { 8, 5 },
                    { 8, 7 },
                    { 9, 5 },
                    { 9, 9 },
                    { 10, 7 },
                    { 10, 9 },
                    { 11, 1 },
                    { 11, 10 },
                    { 12, 8 },
                    { 12, 10 },
                    { 13, 3 },
                    { 13, 7 },
                    { 14, 5 },
                    { 14, 9 },
                    { 15, 3 },
                    { 15, 9 },
                    { 16, 4 },
                    { 16, 8 },
                    { 17, 2 },
                    { 17, 6 },
                    { 17, 10 },
                    { 18, 4 },
                    { 18, 8 },
                    { 19, 2 },
                    { 19, 6 },
                    { 19, 10 },
                    { 20, 1 },
                    { 20, 3 },
                    { 20, 5 },
                    { 21, 2 },
                    { 21, 4 },
                    { 22, 1 },
                    { 22, 2 },
                    { 22, 3 },
                    { 22, 4 },
                    { 23, 4 },
                    { 23, 5 },
                    { 24, 1 },
                    { 24, 3 },
                    { 24, 5 }
                });

            migrationBuilder.InsertData(
                table: "LessonVisitor",
                columns: new[] { "LessonId", "VisitorId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 6 },
                    { 3, 5 },
                    { 3, 7 },
                    { 3, 9 },
                    { 4, 1 },
                    { 4, 8 },
                    { 4, 10 },
                    { 5, 3 },
                    { 5, 5 },
                    { 5, 7 },
                    { 5, 9 },
                    { 6, 2 },
                    { 6, 4 },
                    { 6, 6 },
                    { 6, 8 },
                    { 6, 10 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 },
                    { 8, 6 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 8, 10 },
                    { 9, 1 },
                    { 9, 4 },
                    { 9, 7 },
                    { 9, 10 },
                    { 10, 2 },
                    { 10, 5 },
                    { 10, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 14, 9 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 15, 9 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 16, 8 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 17, 10 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 18, 8 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 19, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 19, 6 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 20, 5 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 21, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 21, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 22, 2 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 22, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 23, 5 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "DateAttendanceVisitor",
                keyColumns: new[] { "DateAttendanceId", "VisitorId" },
                keyValues: new object[] { 24, 5 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "LessonVisitor",
                keyColumns: new[] { "LessonId", "VisitorId" },
                keyValues: new object[] { 10, 8 });
        }
    }
}
