using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_Id",
                table: "ImagesNewsModels");

            migrationBuilder.DropColumn(
                name: "Image_Id",
                table: "ImagesEventModels");

            migrationBuilder.DropColumn(
                name: "UrlTitleImag_Id",
                table: "EventModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Image_Id",
                table: "ImagesNewsModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Image_Id",
                table: "ImagesEventModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UrlTitleImag_Id",
                table: "EventModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
