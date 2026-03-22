using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDBNewsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventModels_EventId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Lessons_LessonId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLesson_Lessons_LessonId",
                table: "ImagesLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesNews_News_NewsId",
                table: "ImagesNews");

            migrationBuilder.DropIndex(
                name: "IX_ImagesNews_NewsId",
                table: "ImagesNews");

            migrationBuilder.DropIndex(
                name: "IX_ImagesLesson_LessonId",
                table: "ImagesLesson");

            migrationBuilder.DropIndex(
                name: "IX_Image_EventId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_LessonId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "ImagesNews");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "ImagesLesson");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Image");

            migrationBuilder.AddColumn<long>(
                name: "NewsEntityId",
                table: "ImagesNews",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LessonEntityId",
                table: "ImagesLesson",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewsModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Author_Value = table.Column<string>(type: "text", nullable: false),
                    Date_Value = table.Column<string>(type: "text", nullable: false),
                    Description_Value = table.Column<string>(type: "text", nullable: false),
                    Title_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsModels_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesNews_NewsEntityId",
                table: "ImagesNews",
                column: "NewsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLesson_LessonEntityId",
                table: "ImagesLesson",
                column: "LessonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsModels_CategoryId",
                table: "NewsModels",
                column: "CategoryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesLesson_Lessons_LessonEntityId",
                table: "ImagesLesson");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesNews_News_NewsEntityId",
                table: "ImagesNews");

            migrationBuilder.DropTable(
                name: "NewsModels");

            migrationBuilder.DropIndex(
                name: "IX_ImagesNews_NewsEntityId",
                table: "ImagesNews");

            migrationBuilder.DropIndex(
                name: "IX_ImagesLesson_LessonEntityId",
                table: "ImagesLesson");

            migrationBuilder.DropColumn(
                name: "NewsEntityId",
                table: "ImagesNews");

            migrationBuilder.DropColumn(
                name: "LessonEntityId",
                table: "ImagesLesson");

            migrationBuilder.AddColumn<long>(
                name: "NewsId",
                table: "ImagesNews",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LessonId",
                table: "ImagesLesson",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LessonId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesNews_NewsId",
                table: "ImagesNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLesson_LessonId",
                table: "ImagesLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_EventId",
                table: "Image",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LessonId",
                table: "Image",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventModels_EventId",
                table: "Image",
                column: "EventId",
                principalTable: "EventModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Lessons_LessonId",
                table: "Image",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesLesson_Lessons_LessonId",
                table: "ImagesLesson",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesNews_News_NewsId",
                table: "ImagesNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
