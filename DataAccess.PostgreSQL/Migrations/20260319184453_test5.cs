using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Category_CategoryId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_EventModels_Image_UrlTitleImagId",
                table: "EventModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventModels_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsModels_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsModels_Category_CategoryId",
                table: "NewsModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsModels",
                table: "NewsModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventModels",
                table: "EventModels");

            migrationBuilder.RenameTable(
                name: "NewsModels",
                newName: "NewsModel");

            migrationBuilder.RenameTable(
                name: "EventModels",
                newName: "EventModel");

            migrationBuilder.RenameIndex(
                name: "IX_NewsModels_CategoryId",
                table: "NewsModel",
                newName: "IX_NewsModel_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EventModels_UrlTitleImagId",
                table: "EventModel",
                newName: "IX_EventModel_UrlTitleImagId");

            migrationBuilder.RenameIndex(
                name: "IX_EventModels_CategoryId",
                table: "EventModel",
                newName: "IX_EventModel_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsModel",
                table: "NewsModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventModel_Category_CategoryId",
                table: "EventModel",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventModel_Image_UrlTitleImagId",
                table: "EventModel",
                column: "UrlTitleImagId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventModel_EntityId",
                table: "Image",
                column: "EntityId",
                principalTable: "EventModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_NewsModel_ImageNews_EntityId",
                table: "Image",
                column: "ImageNews_EntityId",
                principalTable: "NewsModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsModel_Category_CategoryId",
                table: "NewsModel",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModel_Category_CategoryId",
                table: "EventModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventModel_Image_UrlTitleImagId",
                table: "EventModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventModel_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_NewsModel_ImageNews_EntityId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsModel_Category_CategoryId",
                table: "NewsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsModel",
                table: "NewsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventModel",
                table: "EventModel");

            migrationBuilder.RenameTable(
                name: "NewsModel",
                newName: "NewsModels");

            migrationBuilder.RenameTable(
                name: "EventModel",
                newName: "EventModels");

            migrationBuilder.RenameIndex(
                name: "IX_NewsModel_CategoryId",
                table: "NewsModels",
                newName: "IX_NewsModels_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EventModel_UrlTitleImagId",
                table: "EventModels",
                newName: "IX_EventModels_UrlTitleImagId");

            migrationBuilder.RenameIndex(
                name: "IX_EventModel_CategoryId",
                table: "EventModels",
                newName: "IX_EventModels_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsModels",
                table: "NewsModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventModels",
                table: "EventModels",
                column: "Id");

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
