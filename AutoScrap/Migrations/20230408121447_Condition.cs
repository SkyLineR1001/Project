using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoScrap.Migrations
{
    public partial class Condition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Part",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Part");
        }
    }
}
