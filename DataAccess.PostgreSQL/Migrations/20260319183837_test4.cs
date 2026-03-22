using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ImageNews_EntityId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_EntityId",
                table: "Image",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageNews_EntityId",
                table: "Image",
                column: "ImageNews_EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventModels_EntityId",
                table: "Image",
                column: "EntityId",
                principalTable: "EventModels",
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
                name: "FK_Image_EventModels_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsModels_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_EntityId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "Discriminator",
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
