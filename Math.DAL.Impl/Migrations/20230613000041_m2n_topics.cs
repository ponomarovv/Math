using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Math.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m2n_topics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Topics_TopicId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Topics_ParentTopicId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_ParentTopicId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Books_TopicId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ParentTopicId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Books");

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

            migrationBuilder.CreateTable(
                name: "BookTopic",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTopic", x => new { x.BooksId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_BookTopic_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenTopicTopic",
                columns: table => new
                {
                    ChildrenTopicsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenTopicTopic", x => new { x.ChildrenTopicsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_ChildrenTopicTopic_ChildrenTopics_ChildrenTopicsId",
                        column: x => x.ChildrenTopicsId,
                        principalTable: "ChildrenTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildrenTopicTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BookTopic_TopicsId",
                table: "BookTopic",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenTopicTopic_TopicsId",
                table: "ChildrenTopicTopic",
                column: "TopicsId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "BookTopic");

            migrationBuilder.DropTable(
                name: "ChildrenTopicTopic");

            migrationBuilder.DropTable(
                name: "ChildrenTopics");

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

            migrationBuilder.AddColumn<int>(
                name: "ParentTopicId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TopicId",
                table: "Books",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Topics_TopicId",
                table: "Books",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Topics_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }
    }
}
