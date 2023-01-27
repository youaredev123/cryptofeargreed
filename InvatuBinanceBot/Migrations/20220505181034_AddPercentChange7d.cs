using Microsoft.EntityFrameworkCore.Migrations;

namespace InvatuBinanceBot.Migrations
{
    public partial class AddPercentChange7d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PercentChange7d",
                table: "Coins",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentChange7d",
                table: "Coins");
        }
    }
}
