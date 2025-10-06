using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAttendanceVisitor");

            migrationBuilder.DropTable(
                name: "LessonVisitor");

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DateAttendances",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Teachers",
                columns: new[] { "Id", "DateBirth", "Login", "Name", "NumberPhone", "Password", "Patronymic", "Surname" },
                values: new object[,]
                {
                    { 1, "30.11.2005", "1234", "Валерий", "89898576246", "1234", "Валентинович", "Терегера" },
                    { 2, "20.12.2005", "1235", "Дмитрий", "89898573246", "1235", "Романович", "Шилов" },
                    { 3, "15.05.1985", "alex1985", "Александр", "89501234567", "alex123", "Сергеевич", "Иванов" },
                    { 4, "22.08.1990", "kate1990", "Екатерина", "89167891234", "kate456", "Андреевна", "Петрова" },
                    { 5, "10.03.1988", "misha88", "Михаил", "89654321987", "misha789", "Дмитриевич", "Смирнов" },
                    { 6, "05.12.1992", "olga92", "Ольга", "89031234567", "olga012", "Игоревна", "Васильева" },
                    { 7, "18.07.1983", "sergey83", "Сергей", "89998765432", "sergey345", "Владимирович", "Кузнецов" },
                    { 8, "25.09.1995", "anna95", "Анна", "89765432109", "anna678", "Александровна", "Новикова" },
                    { 9, "12.01.1980", "alex80", "Алексей", "89261234567", "alex901", "Олегович", "Федоров" },
                    { 10, "08.04.1987", "nata87", "Наталья", "89111234567", "nata234", "Викторовна", "Морозова" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "DateBirth", "Login", "Name", "NumberPhone", "Password", "Patronymic", "Surname" },
                values: new object[,]
                {
                    { 1, "30.11.2005", "1234", "Валерий", "89898576246", "1234", "Валентинович", "Терегера" },
                    { 2, "20.12.2005", "1235", "Дмитрий", "89898573246", "1235", "Романович", "Шилов" },
                    { 3, "15.03.2007", "alex2007", "Алексей", "89876543210", "alexpass", "Игоревич", "Петров" },
                    { 4, "22.05.2006", "elena2006", "Елена", "89123456789", "elenapass", "Дмитриевна", "Смирнова" },
                    { 5, "10.08.2005", "ivan2005", "Иван", "89012345678", "ivanpass", "Сергеевич", "Кузнецов" },
                    { 6, "05.12.2006", "olga2006", "Ольга", "89234567890", "olgapass", "Андреевна", "Васильева" },
                    { 7, "18.02.2007", "sergey2007", "Сергей", "89345678901", "sergeypass", "Алексеевич", "Новиков" },
                    { 8, "25.09.2006", "anna2006", "Анна", "89456789012", "annapass", "Викторовна", "Федорова" },
                    { 9, "12.07.2005", "misha2005", "Михаил", "89567890123", "mishapass", "Олегович", "Иванов" },
                    { 10, "08.04.2007", "natalia2007", "Наталья", "89678901234", "natpass", "Сергеевна", "Морозова" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Застава", 1 },
                    { 2, "Программирование", 2 },
                    { 3, "Робототехника", 1 },
                    { 4, "Шахматы", 1 },
                    { 5, "ИЗО", 5 },
                    { 6, "Театральный", 6 },
                    { 7, "Футбол", 7 },
                    { 8, "Волейбол", 8 },
                    { 9, "Английский", 9 },
                    { 10, "Математика", 10 }
                });

            migrationBuilder.InsertData(
                table: "DateAttendances",
                columns: new[] { "Id", "Date", "LessonId" },
                values: new object[,]
                {
                    { 1, "01.05.2025", 1 },
                    { 2, "08.05.2025", 1 },
                    { 3, "15.05.2025", 1 },
                    { 4, "02.05.2025", 2 },
                    { 5, "09.05.2025", 2 },
                    { 6, "16.05.2025", 2 },
                    { 7, "23.05.2025", 2 },
                    { 8, "03.05.2025", 3 },
                    { 9, "10.05.2025", 3 },
                    { 10, "17.05.2025", 3 },
                    { 11, "04.05.2025", 4 },
                    { 12, "18.05.2025", 4 },
                    { 13, "05.05.2025", 5 },
                    { 14, "12.05.2025", 5 },
                    { 15, "19.05.2025", 5 },
                    { 16, "06.05.2025", 6 },
                    { 17, "13.05.2025", 6 },
                    { 18, "20.05.2025", 6 },
                    { 19, "27.05.2025", 6 },
                    { 20, "07.05.2025", 7 },
                    { 21, "14.05.2025", 7 },
                    { 22, "21.05.2025", 7 },
                    { 23, "28.05.2025", 7 },
                    { 24, "04.06.2025", 7 }
                });

            migrationBuilder.InsertData(
                table: "LessonVisitor",
                columns: new[] { "LessonId", "VisitorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
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

            migrationBuilder.InsertData(
                table: "DateAttendanceVisitor",
                columns: new[] { "DateAttendanceId", "VisitorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
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

            migrationBuilder.CreateIndex(
                name: "IX_DateAttendanceVisitor_VisitorId",
                table: "DateAttendanceVisitor",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonVisitor_VisitorId",
                table: "LessonVisitor",
                column: "VisitorId");
        }
    }
}
