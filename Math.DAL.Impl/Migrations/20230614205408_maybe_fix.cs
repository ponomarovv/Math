using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Math.DAL.Migrations
{
    /// <inheritdoc />
    public partial class maybe_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Topics_MainTopicId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "TopicQuiz");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_MainTopicId",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "MainTopicText",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "QuizTopic",
                columns: table => new
                {
                    QuizzesId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTopic", x => new { x.QuizzesId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_QuizTopic_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizTopic_TopicsId",
                table: "QuizTopic",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizTopic");

            migrationBuilder.DropColumn(
                name: "MainTopicText",
                table: "Quizzes");

            migrationBuilder.CreateTable(
                name: "TopicQuiz",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicQuiz", x => new { x.TopicId, x.QuizId });
                    table.ForeignKey(
                        name: "FK_TopicQuiz_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicQuiz_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_MainTopicId",
                table: "Quizzes",
                column: "MainTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicQuiz_QuizId",
                table: "TopicQuiz",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Topics_MainTopicId",
                table: "Quizzes",
                column: "MainTopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
