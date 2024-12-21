using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabooGameApi.Migrations
{
    /// <inheritdoc />
    public partial class LevelTableRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Words_LevelId",
                table: "Words",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Levels_LevelId",
                table: "Words",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Levels_LevelId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_LevelId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Words");
        }
    }
}
