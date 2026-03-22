using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddDBEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesEvent_Events_EventId",
                table: "ImagesEvent");

            migrationBuilder.DropIndex(
                name: "IX_ImagesEvent_EventId",
                table: "ImagesEvent");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ImagesEvent");

            migrationBuilder.AddColumn<long>(
                name: "EventEntityId",
                table: "ImagesEvent",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesEvent_EventEntityId",
                table: "ImagesEvent",
                column: "EventEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesEvent_Events_EventEntityId",
                table: "ImagesEvent",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesEvent_Events_EventEntityId",
                table: "ImagesEvent");

            migrationBuilder.DropTable(
                name: "EventModels");

            migrationBuilder.DropIndex(
                name: "IX_ImagesEvent_EventEntityId",
                table: "ImagesEvent");

            migrationBuilder.DropColumn(
                name: "EventEntityId",
                table: "ImagesEvent");

            migrationBuilder.AddColumn<long>(
                name: "EventId",
                table: "ImagesEvent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ImagesEvent_EventId",
                table: "ImagesEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesEvent_Events_EventId",
                table: "ImagesEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
