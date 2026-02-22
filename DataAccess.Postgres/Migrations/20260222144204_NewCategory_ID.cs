using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class NewCategory_ID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCategory",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "idCategory",
                table: "News",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
