using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _28032024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutImageUrl",
                table: "Abouts",
                newName: "AboutIcon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutIcon",
                table: "Abouts",
                newName: "AboutImageUrl");
        }
    }
}
