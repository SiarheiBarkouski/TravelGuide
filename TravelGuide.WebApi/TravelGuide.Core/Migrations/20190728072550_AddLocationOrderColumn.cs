using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelGuide.Core.Migrations
{
    public partial class AddLocationOrderColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationOrder",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationOrder",
                table: "Locations");
        }
    }
}
