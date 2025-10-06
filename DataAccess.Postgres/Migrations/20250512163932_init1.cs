using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 3, "Робототехника", 3 },
                    { 4, "Шахматы", 4 },
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

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
        }
    }
}
