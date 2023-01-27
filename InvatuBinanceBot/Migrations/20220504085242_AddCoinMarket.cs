using Microsoft.EntityFrameworkCore.Migrations;

namespace InvatuBinanceBot.Migrations
{
    public partial class AddCoinMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoinMarketID",
                table: "Coins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoinMarketID",
                table: "Coins");
        }
    }
}
