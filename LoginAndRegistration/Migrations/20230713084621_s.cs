using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyForm.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionItem",
                table: "QuestionItem");

            migrationBuilder.RenameTable(
                name: "QuestionItem",
                newName: "QuestionItems");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionItem_QuestionId",
                table: "QuestionItems",
                newName: "IX_QuestionItems_QuestionId");

            migrationBuilder.AddColumn<int>(
                name: "DisablerItemId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnabblerItemId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequierd",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxLengh",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minlengh",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionItems",
                table: "QuestionItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DisablerItemId",
                table: "Questions",
                column: "DisablerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EnabblerItemId",
                table: "Questions",
                column: "EnabblerItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItems_Questions_QuestionId",
                table: "QuestionItems",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionItems_DisablerItemId",
                table: "Questions",
                column: "DisablerItemId",
                principalTable: "QuestionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionItems_EnabblerItemId",
                table: "Questions",
                column: "EnabblerItemId",
                principalTable: "QuestionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionItems_Questions_QuestionId",
                table: "QuestionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionItems_DisablerItemId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionItems_EnabblerItemId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DisablerItemId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_EnabblerItemId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionItems",
                table: "QuestionItems");

            migrationBuilder.DropColumn(
                name: "DisablerItemId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EnabblerItemId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsRequierd",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "MaxLengh",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Minlengh",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "QuestionItems",
                newName: "QuestionItem");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionItems_QuestionId",
                table: "QuestionItem",
                newName: "IX_QuestionItem_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionItem",
                table: "QuestionItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionItem_Questions_QuestionId",
                table: "QuestionItem",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
