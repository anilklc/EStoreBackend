using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _05042024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SliderImageUrl",
                table: "Sliders",
                newName: "SliderImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SliderImagePath",
                table: "Sliders",
                newName: "SliderImageUrl");
        }
    }
}
