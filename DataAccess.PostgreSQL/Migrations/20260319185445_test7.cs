using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Image_UrlTitleImagId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventModels_EventModelId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsModels_NewsModelId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_EventModels_UrlTitleImagId",
                table: "EventModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_EventModelId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "EventModelId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "ImagesNewsModels");

            migrationBuilder.RenameColumn(
                name: "UrlTitleImagId",
                table: "EventModels",
                newName: "UrlTitleImag_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Image_NewsModelId",
                table: "ImagesNewsModels",
                newName: "IX_ImagesNewsModels_NewsModelId");

            migrationBuilder.AddColumn<string>(
                name: "UrlTitleImag_Value",
                table: "EventModels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesNewsModels",
                table: "ImagesNewsModels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ImagesEventModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventModelId = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ImagesEventModels_EventModelId",
                table: "ImagesEventModels",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesNewsModels_NewsModels_NewsModelId",
                table: "ImagesNewsModels",
                column: "NewsModelId",
                principalTable: "NewsModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesNewsModels_NewsModels_NewsModelId",
                table: "ImagesNewsModels");

            migrationBuilder.DropTable(
                name: "ImagesEventModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesNewsModels",
                table: "ImagesNewsModels");

            migrationBuilder.DropColumn(
                name: "UrlTitleImag_Value",
                table: "EventModels");

            migrationBuilder.RenameTable(
                name: "ImagesNewsModels",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "UrlTitleImag_Id",
                table: "EventModels",
                newName: "UrlTitleImagId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesNewsModels_NewsModelId",
                table: "Image",
                newName: "IX_Image_NewsModelId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Image",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "EntityId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EventModelId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImageNews_EntityId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Image",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventModels_UrlTitleImagId",
                table: "EventModels",
                column: "UrlTitleImagId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_EventModelId",
                table: "Image",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventModels_Image_UrlTitleImagId",
                table: "EventModels",
                column: "UrlTitleImagId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventModels_EventModelId",
                table: "Image",
                column: "EventModelId",
                principalTable: "EventModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsModels_NewsModelId",
                table: "Image",
                column: "NewsModelId",
                principalTable: "NewsModels",
                principalColumn: "Id");
        }
    }
}
