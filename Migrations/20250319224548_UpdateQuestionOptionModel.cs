using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuestionOptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "question_option",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "question_option",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "question_option");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "question_option");
        }
    }
}
