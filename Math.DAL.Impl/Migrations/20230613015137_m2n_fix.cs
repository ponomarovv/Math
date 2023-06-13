using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Math.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m2n_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ChildrenTopics_ChildrenTopicId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ChildrenTopics_ChildrenTopicId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_ChildrenTopics_ChildrenTopicId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ChildrenTopicId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ChildrenTopicId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Books_ChildrenTopicId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ChildrenTopicId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ChildrenTopicId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ChildrenTopicId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildrenTopicId",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildrenTopicId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildrenTopicId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ChildrenTopicId",
                table: "Quizzes",
                column: "ChildrenTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChildrenTopicId",
                table: "Questions",
                column: "ChildrenTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ChildrenTopicId",
                table: "Books",
                column: "ChildrenTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ChildrenTopics_ChildrenTopicId",
                table: "Books",
                column: "ChildrenTopicId",
                principalTable: "ChildrenTopics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ChildrenTopics_ChildrenTopicId",
                table: "Questions",
                column: "ChildrenTopicId",
                principalTable: "ChildrenTopics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_ChildrenTopics_ChildrenTopicId",
                table: "Quizzes",
                column: "ChildrenTopicId",
                principalTable: "ChildrenTopics",
                principalColumn: "Id");
        }
    }
}
