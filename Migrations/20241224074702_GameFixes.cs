using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabooGameApi.Migrations
{
    /// <inheritdoc />
    public partial class GameFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "WrongAnswer",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WrongAnswer",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
