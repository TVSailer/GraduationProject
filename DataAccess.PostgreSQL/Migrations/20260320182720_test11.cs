using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Category_CategoryId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsModels_Category_CategoryId",
                table: "NewsModels");

            migrationBuilder.DropTable(
                name: "DateAttendanceEntityVisitorEntity");

            migrationBuilder.DropTable(
                name: "ImagesEventModels");

            migrationBuilder.DropTable(
                name: "ImagesLesson");

            migrationBuilder.DropTable(
                name: "ImagesNewsModels");

            migrationBuilder.DropTable(
                name: "LessonEntityVisitorEntity");

            migrationBuilder.DropTable(
                name: "LessonSchedule");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "DateAttendances");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Auths");

            migrationBuilder.RenameColumn(
                name: "Title_Value",
                table: "NewsModels",
                newName: "TitleP_Value");

            migrationBuilder.RenameColumn(
                name: "Description_Value",
                table: "NewsModels",
                newName: "DescriptionP_Value");

            migrationBuilder.RenameColumn(
                name: "Schedule_Start",
                table: "EventModels",
                newName: "Schedule_Start_Value");

            migrationBuilder.RenameColumn(
                name: "Schedule_End",
                table: "EventModels",
                newName: "Schedule_End_Value");

            migrationBuilder.RenameColumn(
                name: "Schedule_Date",
                table: "EventModels",
                newName: "Schedule_Date_Value");

            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageEventModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImageP_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEventModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageEventModel_EventModels_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "EventModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageNewsModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImageP_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageNewsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageNewsModel_NewsModels_NewsModelId",
                        column: x => x.NewsModelId,
                        principalTable: "NewsModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageEventModel_EventModelId",
                table: "ImageEventModel",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageNewsModel_NewsModelId",
                table: "ImageNewsModel",
                column: "NewsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventModels_CategoryModel_CategoryId",
                table: "EventModels",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsModels_CategoryModel_CategoryId",
                table: "NewsModels",
                column: "CategoryId",
                principalTable: "CategoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_CategoryModel_CategoryId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsModels_CategoryModel_CategoryId",
                table: "NewsModels");

            migrationBuilder.DropTable(
                name: "CategoryModel");

            migrationBuilder.DropTable(
                name: "ImageEventModel");

            migrationBuilder.DropTable(
                name: "ImageNewsModel");

            migrationBuilder.RenameColumn(
                name: "TitleP_Value",
                table: "NewsModels",
                newName: "Title_Value");

            migrationBuilder.RenameColumn(
                name: "DescriptionP_Value",
                table: "NewsModels",
                newName: "Description_Value");

            migrationBuilder.RenameColumn(
                name: "Schedule_Start_Value",
                table: "EventModels",
                newName: "Schedule_Start");

            migrationBuilder.RenameColumn(
                name: "Schedule_End_Value",
                table: "EventModels",
                newName: "Schedule_End");

            migrationBuilder.RenameColumn(
                name: "Schedule_Date_Value",
                table: "EventModels",
                newName: "Schedule_Date");

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
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesEventModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventModelId = table.Column<long>(type: "bigint", nullable: true),
                    Image_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesEventModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesEventModels_EventModels_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "EventModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImagesNewsModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsModelId = table.Column<long>(type: "bigint", nullable: true),
                    Image_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesNewsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesNewsModels_NewsModels_NewsModelId",
                        column: x => x.NewsModelId,
                        principalTable: "NewsModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthId = table.Column<long>(type: "bigint", nullable: false),
                    DateBirth = table.Column<string>(type: "text", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false),
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
                    AuthId = table.Column<long>(type: "bigint", nullable: false),
                    DateBirth = table.Column<string>(type: "text", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false),
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
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
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
                name: "DateAttendances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false)
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
                name: "ImagesLesson",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesLesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesLesson_Lessons_LessonEntityId",
                        column: x => x.LessonEntityId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
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
                    Day = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Start = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
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
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    VisitorId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_ImagesEventModels_EventModelId",
                table: "ImagesEventModels",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLesson_LessonEntityId",
                table: "ImagesLesson",
                column: "LessonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesNewsModels_NewsModelId",
                table: "ImagesNewsModels",
                column: "NewsModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventModels_Category_CategoryId",
                table: "EventModels",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsModels_Category_CategoryId",
                table: "NewsModels",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
