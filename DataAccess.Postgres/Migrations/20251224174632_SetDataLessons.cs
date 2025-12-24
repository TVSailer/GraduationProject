using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class SetDataLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Category", "CurrentParticipants", "Description", "Location", "MaxParticipants", "Name", "Rating", "ReviewCount", "Schedule", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Йога", 15, "Класс йоги для новичков", "Зал 1", 20, "Йога для начинающих", 4.7999999999999998, 42, "Пн, Ср, Пт 18:00-19:30", 1 },
                    { 2, "Фитнес", 12, "Высокоинтенсивный интервальный тренинг", "Зал 2", 15, "HIIT тренировка", 4.5999999999999996, 35, "Вт, Чт 19:00-20:00", 2 },
                    { 3, "Пилатес", 20, "Урок пилатеса для всех уровней", "Зал 3", 25, "Пилатес", 4.9000000000000004, 58, "Пн, Ср, Пт 10:00-11:00", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
