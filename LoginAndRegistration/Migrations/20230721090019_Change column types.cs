using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyForm.Migrations
{
    public partial class Changecolumntypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "Nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpanishText",
                table: "Questions",
                type: "Nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Questions",
                type: "Nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Minlengh",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxLengh",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "QuestionItems",
                type: "Varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "QuestionItems",
                type: "Nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Applications",
                type: "Varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "Applications",
                type: "Nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ApplicationParts",
                type: "Varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "ApplicationParts",
                type: "Nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "SpanishText",
                table: "Questions",
                type: "Nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(10)");

            migrationBuilder.AlterColumn<int>(
                name: "Minlengh",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxLengh",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "QuestionItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "QuestionItems",
                type: "Nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "Applications",
                type: "Nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ApplicationParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "SpanishTitle",
                table: "ApplicationParts",
                type: "Nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Nvarchar(MAX)");
        }
    }
}
