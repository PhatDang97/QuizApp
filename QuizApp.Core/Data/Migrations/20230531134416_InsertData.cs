using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: new Guid("63f6605c-b931-4bd5-99eb-2ea550783df1"));

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("73dc1650-190f-4f7c-85dd-0d081f46500d"), "Popular" });

            migrationBuilder.InsertData(
                table: "QuestionGroup",
                columns: new[] { "Id", "Name", "TopicId" },
                values: new object[] { new Guid("ac4f2827-df64-4867-aeac-603c004a87e9"), "Graphic Design", new Guid("73dc1650-190f-4f7c-85dd-0d081f46500d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionGroup",
                keyColumn: "Id",
                keyValue: new Guid("ac4f2827-df64-4867-aeac-603c004a87e9"));

            migrationBuilder.DeleteData(
                table: "Topic",
                keyColumn: "Id",
                keyValue: new Guid("73dc1650-190f-4f7c-85dd-0d081f46500d"));

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("63f6605c-b931-4bd5-99eb-2ea550783df1"), "Popular" });
        }
    }
}
