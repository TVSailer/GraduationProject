using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAttendanceEntityVisitorEntity");

            migrationBuilder.DropTable(
                name: "LessonEntityVisitorEntity");

            migrationBuilder.CreateTable(
                name: "DateAttendanceVisitor",
                columns: table => new
                {
                    DateAttendanceId = table.Column<int>(type: "integer", nullable: false),
                    VisitorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAttendanceVisitor", x => new { x.DateAttendanceId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_DateAttendanceVisitor_DateAttendances_DateAttendanceId",
                        column: x => x.DateAttendanceId,
                        principalTable: "DateAttendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateAttendanceVisitor_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonVisitor",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    VisitorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonVisitor", x => new { x.LessonId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_LessonVisitor_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonVisitor_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DateAttendanceVisitor",
                columns: new[] { "DateAttendanceId", "VisitorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "LessonVisitor",
                columns: new[] { "LessonId", "VisitorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateAttendanceVisitor_VisitorId",
                table: "DateAttendanceVisitor",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonVisitor_VisitorId",
                table: "LessonVisitor",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAttendanceVisitor");

            migrationBuilder.DropTable(
                name: "LessonVisitor");

            migrationBuilder.CreateTable(
                name: "DateAttendanceEntityVisitorEntity",
                columns: table => new
                {
                    DatesId = table.Column<int>(type: "integer", nullable: false),
                    VisitorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAttendanceEntityVisitorEntity", x => new { x.DatesId, x.VisitorsId });
                    table.ForeignKey(
                        name: "FK_DateAttendanceEntityVisitorEntity_DateAttendances_DatesId",
                        column: x => x.DatesId,
                        principalTable: "DateAttendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateAttendanceEntityVisitorEntity_Visitors_VisitorsId",
                        column: x => x.VisitorsId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonEntityVisitorEntity",
                columns: table => new
                {
                    LessonsId = table.Column<int>(type: "integer", nullable: false),
                    VisitorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonEntityVisitorEntity", x => new { x.LessonsId, x.VisitorsId });
                    table.ForeignKey(
                        name: "FK_LessonEntityVisitorEntity_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonEntityVisitorEntity_Visitors_VisitorsId",
                        column: x => x.VisitorsId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateAttendanceEntityVisitorEntity_VisitorsId",
                table: "DateAttendanceEntityVisitorEntity",
                column: "VisitorsId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEntityVisitorEntity_VisitorsId",
                table: "LessonEntityVisitorEntity",
                column: "VisitorsId");
        }
    }
}
