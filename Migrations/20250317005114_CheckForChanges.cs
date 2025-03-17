using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmadeusAPI.Migrations
{
    /// <inheritdoc />
    public partial class CheckForChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_QuestionId",
                table: "QuestionOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionOptions",
                table: "QuestionOptions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "QuestionOptions",
                newName: "question_option");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Question",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Question",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Question",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "question_option",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "question_option",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "question_option",
                newName: "question_id");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "question_option",
                newName: "IX_question_option_question_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_question_option",
                table: "question_option",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_question_option_Question_question_id",
                table: "question_option",
                column: "question_id",
                principalTable: "Question",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_question_option_Question_question_id",
                table: "question_option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_question_option",
                table: "question_option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "question_option",
                newName: "QuestionOptions");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "QuestionOptions",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "QuestionOptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "QuestionOptions",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_question_option_question_id",
                table: "QuestionOptions",
                newName: "IX_QuestionOptions_QuestionId");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Questions",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Questions",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Questions",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionOptions",
                table: "QuestionOptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
