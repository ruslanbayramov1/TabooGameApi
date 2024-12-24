using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabooGameApi.Migrations
{
    /// <inheritdoc />
    public partial class GameStatusAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Inactive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Games");
        }
    }
}
