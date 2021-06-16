using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApp.Migrations
{
    public partial class AddedDeletedPropertyToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("42bbeb19-d7c0-4847-8483-f4c91aa3a093"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("59f411ff-29f9-4c83-b2f0-4508b6e02b4d"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("86d947d0-ab60-4621-8a94-e6bc097b1844"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("9a60b89c-2235-4aea-8264-ed2789a4951c"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Student",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("6b7e053a-70c1-411b-a9a8-b3fea29ce497"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("324a960a-f0c2-497f-888f-f4dbcb5e3947"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("280b4e48-56b3-42d4-8b3e-7519d754e9b9"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("ea32101a-3307-4ebc-9f27-afab8245b52d"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("280b4e48-56b3-42d4-8b3e-7519d754e9b9"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("324a960a-f0c2-497f-888f-f4dbcb5e3947"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("6b7e053a-70c1-411b-a9a8-b3fea29ce497"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("ea32101a-3307-4ebc-9f27-afab8245b52d"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Student");

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("9a60b89c-2235-4aea-8264-ed2789a4951c"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("86d947d0-ab60-4621-8a94-e6bc097b1844"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("42bbeb19-d7c0-4847-8483-f4c91aa3a093"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("59f411ff-29f9-4c83-b2f0-4508b6e02b4d"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") }
                });
        }
    }
}
