using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _06042024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderImagePath",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ReviewImagePath",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "ReviewImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewImage_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderImage_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewImage_ReviewId",
                table: "ReviewImage",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderImage_SliderId",
                table: "SliderImage",
                column: "SliderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewImage");

            migrationBuilder.DropTable(
                name: "SliderImage");

            migrationBuilder.AddColumn<string>(
                name: "SliderImagePath",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewImagePath",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
