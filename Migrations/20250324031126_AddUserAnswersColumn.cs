using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAnswersColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question_id",
                table: "User_answers");

            migrationBuilder.DropColumn(
                name: "Question_option_id",
                table: "User_answers");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "User_answers",
                newName: "user_id");

            migrationBuilder.AddColumn<string[]>(
                name: "Answers",
                table: "User_answers",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "User_answers",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "question_option",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "question_option",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "question_option",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UnmissablePlace",
                table: "City",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "City",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Continent",
                table: "City",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityHash",
                table: "City",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_answers_UserId",
                table: "User_answers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_answers_Users_UserId",
                table: "User_answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_answers_Users_UserId",
                table: "User_answers");

            migrationBuilder.DropIndex(
                name: "IX_User_answers_UserId",
                table: "User_answers");

            migrationBuilder.DropColumn(
                name: "Answers",
                table: "User_answers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User_answers");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "User_answers",
                newName: "User_id");

            migrationBuilder.AddColumn<int>(
                name: "Question_id",
                table: "User_answers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Question_option_id",
                table: "User_answers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "question_option",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "question_option",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "question_option",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnmissablePlace",
                table: "City",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "City",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Continent",
                table: "City",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CityHash",
                table: "City",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
