using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "News",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "News",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "UrlImg",
                table: "Event",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "RegistrationLink");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "News",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentParticipants",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Lessons",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentParticipants",
                table: "Event",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Event",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Organizer",
                table: "Event",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ImgEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgLesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    LessonEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Lessons_LessonEntityId",
                        column: x => x.LessonEntityId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImgEvent_EventId",
                table: "ImgEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgLesson_LessonId",
                table: "ImgLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_LessonEntityId",
                table: "Review",
                column: "LessonEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgEvent");

            migrationBuilder.DropTable(
                name: "ImgLesson");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CurrentParticipants",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CurrentParticipants",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Organizer",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "News",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "News",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Event",
                newName: "UrlImg");

            migrationBuilder.RenameColumn(
                name: "RegistrationLink",
                table: "Event",
                newName: "Name");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Event",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
