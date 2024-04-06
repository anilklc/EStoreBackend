using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _06042024_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "CategoryHrefUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryHrefUrl",
                table: "Categories",
                newName: "CategoryDescription");
        }
    }
}
