using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDBEventModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "EventModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Organizer_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationLink_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Schedule_Date",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Schedule_End",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Schedule_Start",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UrlTitleImagId",
                table: "EventModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventModels_CategoryId",
                table: "EventModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventModels_UrlTitleImagId",
                table: "EventModels",
                column: "UrlTitleImagId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventModels_Category_CategoryId",
                table: "EventModels",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventModels_Image_UrlTitleImagId",
                table: "EventModels",
                column: "UrlTitleImagId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Category_CategoryId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Image_UrlTitleImagId",
                table: "EventModels");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_EventModels_CategoryId",
                table: "EventModels");

            migrationBuilder.DropIndex(
                name: "IX_EventModels_UrlTitleImagId",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Description_Value",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Location_Value",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Organizer_Value",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "RegistrationLink_Value",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Schedule_Date",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Schedule_End",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Schedule_Start",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "Title_Value",
                table: "EventModels");

            migrationBuilder.DropColumn(
                name: "UrlTitleImagId",
                table: "EventModels");
        }
    }
}
