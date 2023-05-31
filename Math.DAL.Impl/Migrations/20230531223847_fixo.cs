using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Math.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Topics");

            migrationBuilder.AddColumn<int>(
                name: "ParentTopicId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Topics_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId",
                principalTable: "Topics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Topics_ParentTopicId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_ParentTopicId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ParentTopicId",
                table: "Topics");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
