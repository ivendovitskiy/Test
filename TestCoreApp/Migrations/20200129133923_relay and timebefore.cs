using Microsoft.EntityFrameworkCore.Migrations;

namespace TestCoreApp.Migrations
{
    public partial class relayandtimebefore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Relay",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeBefore",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relay",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "TimeBefore",
                table: "Devices");
        }
    }
}
