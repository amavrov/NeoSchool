using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoSchool.Data.Migrations
{
    public partial class disciplines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Materials_MaterialId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_VideoLessons_VideoLessonId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_MaterialId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_VideoLessonId",
                table: "Disciplines");

            migrationBuilder.AlterColumn<string>(
                name: "VideoLessonId",
                table: "Disciplines",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialId",
                table: "Disciplines",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId1",
                table: "Disciplines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoLessonId1",
                table: "Disciplines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_MaterialId1",
                table: "Disciplines",
                column: "MaterialId1");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_VideoLessonId1",
                table: "Disciplines",
                column: "VideoLessonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Materials_MaterialId1",
                table: "Disciplines",
                column: "MaterialId1",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_VideoLessons_VideoLessonId1",
                table: "Disciplines",
                column: "VideoLessonId1",
                principalTable: "VideoLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Materials_MaterialId1",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_VideoLessons_VideoLessonId1",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_MaterialId1",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_VideoLessonId1",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "MaterialId1",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "VideoLessonId1",
                table: "Disciplines");

            migrationBuilder.AlterColumn<int>(
                name: "VideoLessonId",
                table: "Disciplines",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Disciplines",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_MaterialId",
                table: "Disciplines",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_VideoLessonId",
                table: "Disciplines",
                column: "VideoLessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Materials_MaterialId",
                table: "Disciplines",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_VideoLessons_VideoLessonId",
                table: "Disciplines",
                column: "VideoLessonId",
                principalTable: "VideoLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
