using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixAnswerLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "SkinTestAnswers");

            migrationBuilder.AddColumn<int>(
                name: "SkinType",
                table: "SkinTestAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkinType",
                table: "SkinTestAnswers");

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "SkinTestAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
