using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Image_Id",
                table: "ImagesNewsModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Image_Value",
                table: "ImagesNewsModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Image_Id",
                table: "ImagesEventModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Image_Value",
                table: "ImagesEventModels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_Id",
                table: "ImagesNewsModels");

            migrationBuilder.DropColumn(
                name: "Image_Value",
                table: "ImagesNewsModels");

            migrationBuilder.DropColumn(
                name: "Image_Id",
                table: "ImagesEventModels");

            migrationBuilder.DropColumn(
                name: "Image_Value",
                table: "ImagesEventModels");
        }
    }
}
