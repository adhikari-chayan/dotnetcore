using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApp.Migrations
{
    public partial class AddProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("5595c844-be85-431d-8e4d-6ca214e5293d"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("8127f00d-b457-4db3-9b0c-21a66639e2db"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("93f45c01-1ab9-4068-8e75-112f4851dbab"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("ee903de5-1ace-43da-966d-d89d03bf3d0d"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("93f45c01-1ab9-4068-8e75-112f4851dbab"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("ee903de5-1ace-43da-966d-d89d03bf3d0d"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("8127f00d-b457-4db3-9b0c-21a66639e2db"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("5595c844-be85-431d-8e4d-6ca214e5293d"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") }
                });
        }
    }
}
