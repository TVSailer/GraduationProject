using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auths",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateBirth = table.Column<string>(type: "text", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false),
                    AuthId = table.Column<long>(type: "bigint", nullable: false),
                    FIO_Name = table.Column<string>(type: "text", nullable: false),
                    FIO_Patronymic = table.Column<string>(type: "text", nullable: false),
                    FIO_Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateBirth = table.Column<string>(type: "text", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false),
                    AuthId = table.Column<long>(type: "bigint", nullable: false),
                    FIO_Name = table.Column<string>(type: "text", nullable: false),
                    FIO_Patronymic = table.Column<string>(type: "text", nullable: false),
                    FIO_Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Auths_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Auths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationLink = table.Column<string>(type: "text", nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: false),
                    CurrentParticipants = table.Column<int>(type: "integer", nullable: false),
                    Schedule_Date = table.Column<string>(type: "text", nullable: false),
                    Schedule_End = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Schedule_Start = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "EventCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_NewsCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "NewsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LessonCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgNews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateAttendances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateAttendances_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgLesson",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "LessonEntityVisitorEntity",
                columns: table => new
                {
                    LessonsId = table.Column<long>(type: "bigint", nullable: false),
                    VisitorsId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LessonSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    End = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonSchedule_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    VisitorId = table.Column<long>(type: "bigint", nullable: false),
                    LessonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateAttendanceEntityVisitorEntity",
                columns: table => new
                {
                    DatesId = table.Column<long>(type: "bigint", nullable: false),
                    VisitorsId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_DateAttendanceEntityVisitorEntity_VisitorsId",
                table: "DateAttendanceEntityVisitorEntity",
                column: "VisitorsId");

            migrationBuilder.CreateIndex(
                name: "IX_DateAttendances_LessonId",
                table: "DateAttendances",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgEvent_EventId",
                table: "ImgEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgLesson_LessonId",
                table: "ImgLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgNews_NewsId",
                table: "ImgNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEntityVisitorEntity_VisitorsId",
                table: "LessonEntityVisitorEntity",
                column: "VisitorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CategoryId",
                table: "Lessons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonSchedule_LessonId",
                table: "LessonSchedule",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_LessonId",
                table: "Reviews",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_VisitorId",
                table: "Reviews",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AuthId",
                table: "Teachers",
                column: "AuthId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_AuthId",
                table: "Visitors",
                column: "AuthId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAttendanceEntityVisitorEntity");

            migrationBuilder.DropTable(
                name: "ImgEvent");

            migrationBuilder.DropTable(
                name: "ImgLesson");

            migrationBuilder.DropTable(
                name: "ImgNews");

            migrationBuilder.DropTable(
                name: "LessonEntityVisitorEntity");

            migrationBuilder.DropTable(
                name: "LessonSchedule");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "DateAttendances");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "EventCategory");

            migrationBuilder.DropTable(
                name: "NewsCategory");

            migrationBuilder.DropTable(
                name: "LessonCategory");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Auths");
        }
    }
}
