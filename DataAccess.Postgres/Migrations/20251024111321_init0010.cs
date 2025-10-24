using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class init0010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImg",
                table: "News");

            migrationBuilder.CreateTable(
                name: "ImgNew",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgNew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImgNew_News_EventId",
                        column: x => x.EventId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImgNew_EventId",
                table: "ImgNew",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgNew");

            migrationBuilder.AddColumn<string>(
                name: "UrlImg",
                table: "News",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
