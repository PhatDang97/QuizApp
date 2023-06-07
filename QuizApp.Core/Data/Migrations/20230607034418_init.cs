using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "QuestionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "ParticipantResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: true),
                    TimeTaken = table.Column<int>(type: "int", nullable: true),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionGroupId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantResult_QuestionGroup_QuestionGroupId1",
                        column: x => x.QuestionGroupId1,
                        principalTable: "QuestionGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParticipantResults_Participant",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParticipantResults_QuestionGroup",
                        column: x => x.QuestionGroupId,
                        principalTable: "QuestionGroup",
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
                values: new object[] { new Guid("92941242-7e5b-4323-af1a-54f03e2a3c63"), "Popular" });

            migrationBuilder.InsertData(
                table: "QuestionGroup",
                columns: new[] { "Id", "Name", "TopicId" },
                values: new object[] { new Guid("37b8b1e7-12de-4303-a91d-89b3543ad139"), "Graphic Design", new Guid("92941242-7e5b-4323-af1a-54f03e2a3c63") });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantResult_ParticipantId",
                table: "ParticipantResult",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantResult_QuestionGroupId",
                table: "ParticipantResult",
                column: "QuestionGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantResult_QuestionGroupId1",
                table: "ParticipantResult",
                column: "QuestionGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionGroupId",
                table: "Question",
                column: "QuestionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGroup_TopicId",
                table: "QuestionGroup",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantResult");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "QuestionGroup");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
