using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoSchool.Data.Migrations
{
    public partial class materialCommentNameEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialComment_AspNetUsers_AuthorId",
                table: "MaterialComment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialComment_Materials_MaterialId",
                table: "MaterialComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialComment",
                table: "MaterialComment");

            migrationBuilder.RenameTable(
                name: "MaterialComment",
                newName: "MaterialComments");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialComment_MaterialId",
                table: "MaterialComments",
                newName: "IX_MaterialComments_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialComment_AuthorId",
                table: "MaterialComments",
                newName: "IX_MaterialComments_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialComments",
                table: "MaterialComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialComments_AspNetUsers_AuthorId",
                table: "MaterialComments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialComments_Materials_MaterialId",
                table: "MaterialComments",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialComments_AspNetUsers_AuthorId",
                table: "MaterialComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialComments_Materials_MaterialId",
                table: "MaterialComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialComments",
                table: "MaterialComments");

            migrationBuilder.RenameTable(
                name: "MaterialComments",
                newName: "MaterialComment");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialComments_MaterialId",
                table: "MaterialComment",
                newName: "IX_MaterialComment_MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_MaterialComments_AuthorId",
                table: "MaterialComment",
                newName: "IX_MaterialComment_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialComment",
                table: "MaterialComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialComment_AspNetUsers_AuthorId",
                table: "MaterialComment",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialComment_Materials_MaterialId",
                table: "MaterialComment",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
