using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDBEventModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "Image",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_EventId",
                table: "Image",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_EventModels_EventId",
                table: "Image",
                column: "EventId",
                principalTable: "EventModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_EventModels_EventId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_EventId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Image");
        }
    }
}
