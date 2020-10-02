using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.NotesApp.Domain.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewlyAddedProperty",
                table: "Notes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewlyAddedProperty",
                table: "Notes");
        }
    }
}
