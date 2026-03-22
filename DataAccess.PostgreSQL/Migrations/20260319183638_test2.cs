using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EntityId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageNews_EntityId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UrlTitleImag = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationLink = table.Column<string>(type: "text", nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: false),
                    Schedule_Date = table.Column<string>(type: "text", nullable: false),
                    Schedule_End = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Schedule_Start = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEntity_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImgEventEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgEventEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgEventEntity_EventEntity_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "EventEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_EntityId",
                table: "Image",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageNews_EntityId",
                table: "Image",
                column: "ImageNews_EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntity_CategoryId",
                table: "EventEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImgEventEntity_EventEntityId",
                table: "ImgEventEntity",
                column: "EventEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventEntity_EntityId",
                table: "Image",
                column: "EntityId",
                principalTable: "EventEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsModels_ImageNews_EntityId",
                table: "Image",
                column: "ImageNews_EntityId",
                principalTable: "NewsModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventEntity_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsModels_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropTable(
                name: "ImgEventEntity");

            migrationBuilder.DropTable(
                name: "EventEntity");

            migrationBuilder.DropIndex(
                name: "IX_Image_EntityId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageNews_EntityId",
                table: "Image");
        }
    }
}
