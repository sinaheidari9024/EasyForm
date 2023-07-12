using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyForm.Migrations
{
    public partial class Casecadeondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_UserApplications_UserApplicationId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationParts_ApplicationPartId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApplications_AspNetUsers_UserId",
                table: "UserApplications");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_UserApplications_UserApplicationId",
                table: "Answer",
                column: "UserApplicationId",
                principalTable: "UserApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationParts_ApplicationPartId",
                table: "Questions",
                column: "ApplicationPartId",
                principalTable: "ApplicationParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplications_AspNetUsers_UserId",
                table: "UserApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_UserApplications_UserApplicationId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationParts_ApplicationPartId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApplications_AspNetUsers_UserId",
                table: "UserApplications");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Questions_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_UserApplications_UserApplicationId",
                table: "Answer",
                column: "UserApplicationId",
                principalTable: "UserApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationParts_ApplicationPartId",
                table: "Questions",
                column: "ApplicationPartId",
                principalTable: "ApplicationParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplications_AspNetUsers_UserId",
                table: "UserApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
