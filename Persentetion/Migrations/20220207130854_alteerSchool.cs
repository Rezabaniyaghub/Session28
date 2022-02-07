using Microsoft.EntityFrameworkCore.Migrations;

namespace Persentetion.Migrations
{
    public partial class alteerSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CretedAt",
                table: "Schools",
                newName: "CreateAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Schools",
                newName: "CretedAt");
        }
    }
}
