using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitorImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAttendanceEntityVisitorEntity_DateAttendances_DatesId",
                table: "DateAttendanceEntityVisitorEntity");

            migrationBuilder.RenameColumn(
                name: "DatesId",
                table: "DateAttendanceEntityVisitorEntity",
                newName: "DateAttendancesId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Visitors",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ImageLessonEntity",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAttendanceEntityVisitorEntity_DateAttendances_DateAtten~",
                table: "DateAttendanceEntityVisitorEntity",
                column: "DateAttendancesId",
                principalTable: "DateAttendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateAttendanceEntityVisitorEntity_DateAttendances_DateAtten~",
                table: "DateAttendanceEntityVisitorEntity");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Visitors");

            migrationBuilder.RenameColumn(
                name: "DateAttendancesId",
                table: "DateAttendanceEntityVisitorEntity",
                newName: "DatesId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "ImageLessonEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_DateAttendanceEntityVisitorEntity_DateAttendances_DatesId",
                table: "DateAttendanceEntityVisitorEntity",
                column: "DatesId",
                principalTable: "DateAttendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
