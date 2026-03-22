using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class test12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEventModel");

            migrationBuilder.DropTable(
                name: "ImageNewsModel");

            migrationBuilder.DropTable(
                name: "EventModels");

            migrationBuilder.DropTable(
                name: "NewsModels");

            migrationBuilder.DropTable(
                name: "CategoryModel");

            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UrlTitleImag = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    RegistrationLink = table.Column<string>(type: "text", nullable: false),
                    Organizer = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Schedule_Date = table.Column<string>(type: "text", nullable: false),
                    Schedule_End = table.Column<string>(type: "text", nullable: false),
                    Schedule_Start = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageEventEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    EventEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEventEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageEventEntity_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageEventEntity_EventEntityId",
                table: "ImageEventEntity",
                column: "EventEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageEventEntity");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.CreateTable(
                name: "CategoryModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description_Value = table.Column<string>(type: "text", nullable: false),
                    Location_Value = table.Column<string>(type: "text", nullable: false),
                    Organizer_Value = table.Column<string>(type: "text", nullable: false),
                    RegistrationLink_Value = table.Column<string>(type: "text", nullable: false),
                    Schedule_Date_Value = table.Column<string>(type: "text", nullable: false),
                    Schedule_End_Value = table.Column<string>(type: "text", nullable: false),
                    Schedule_Start_Value = table.Column<string>(type: "text", nullable: false),
                    Title_Value = table.Column<string>(type: "text", nullable: false),
                    UrlTitleImag_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventModels_CategoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Author_Value = table.Column<string>(type: "text", nullable: false),
                    Date_Value = table.Column<string>(type: "text", nullable: false),
                    DescriptionP_Value = table.Column<string>(type: "text", nullable: false),
                    TitleP_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsModels_CategoryModel_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageEventModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImageP_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageEventModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageEventModel_EventModels_EventModelId",
                        column: x => x.EventModelId,
                        principalTable: "EventModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageNewsModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImageP_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageNewsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageNewsModel_NewsModels_NewsModelId",
                        column: x => x.NewsModelId,
                        principalTable: "NewsModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventModels_CategoryId",
                table: "EventModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageEventModel_EventModelId",
                table: "ImageEventModel",
                column: "EventModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageNewsModel_NewsModelId",
                table: "ImageNewsModel",
                column: "NewsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsModels_CategoryId",
                table: "NewsModels",
                column: "CategoryId");
        }
    }
}
