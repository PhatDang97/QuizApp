using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    TimeTaken = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    TimeTaken = table.Column<int>(type: "int", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantResult_Result",
                        column: x => x.ParticipantResultId,
                        principalTable: "ParticipantResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionGroups_Topic",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Option6 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Answer = table.Column<int>(type: "int", nullable: true),
                    QuestionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionGroup_Questions",
                        column: x => x.QuestionGroupId,
                        principalTable: "QuestionGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("53852352-75ae-48b2-8b76-b08064c3e34f"), "Popular" });

            migrationBuilder.InsertData(
                table: "QuestionGroup",
                columns: new[] { "Id", "Name", "TopicId", "TotalQuestion" },
                values: new object[] { new Guid("a033f89a-a1fd-48a2-8b9e-ba9258414f09"), "Graphic Design", new Guid("53852352-75ae-48b2-8b76-b08064c3e34f"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionGroupId",
                table: "Question",
                column: "QuestionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGroup_TopicId",
                table: "QuestionGroup",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_ParticipantResultId",
                table: "QuizResults",
                column: "ParticipantResultId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuizResults");

            migrationBuilder.DropTable(
                name: "QuestionGroup");

            migrationBuilder.DropTable(
                name: "ParticipantResult");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
