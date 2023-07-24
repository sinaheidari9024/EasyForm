using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyForm.Migrations
{
    public partial class addspanish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpanishText",
                table: "Questions",
                type: "Nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpanishTitle",
                table: "QuestionItems",
                type: "Nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpanishTitle",
                table: "Applications",
                type: "Nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpanishTitle",
                table: "ApplicationParts",
                type: "Nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpanishText",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SpanishTitle",
                table: "QuestionItems");

            migrationBuilder.DropColumn(
                name: "SpanishTitle",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SpanishTitle",
                table: "ApplicationParts");
        }
    }
}
