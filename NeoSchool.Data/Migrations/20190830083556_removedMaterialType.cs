using Microsoft.EntityFrameworkCore.Migrations;

namespace NeoSchool.Data.Migrations
{
    public partial class removedMaterialType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Materials",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Materials",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
