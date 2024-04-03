using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _04042024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewImageUrl",
                table: "Reviews",
                newName: "ReviewImagePath");

            migrationBuilder.AddColumn<bool>(
                name: "ReviewImageControl",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewImageControl",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewImagePath",
                table: "Reviews",
                newName: "ReviewImageUrl");
        }
    }
}
