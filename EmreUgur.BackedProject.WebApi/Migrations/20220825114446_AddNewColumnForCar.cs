using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmreUgur.BackedProject.WebApi.Migrations
{
    public partial class AddNewColumnForCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHeadlightOn",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHeadlightOn",
                table: "Cars");
        }
    }
}
