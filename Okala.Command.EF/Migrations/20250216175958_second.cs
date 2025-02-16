using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okala.Command.EF.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceAUD",
                table: "cryptos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceBRL",
                table: "cryptos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceEUR",
                table: "cryptos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceGBP",
                table: "cryptos",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceAUD",
                table: "cryptos");

            migrationBuilder.DropColumn(
                name: "PriceBRL",
                table: "cryptos");

            migrationBuilder.DropColumn(
                name: "PriceEUR",
                table: "cryptos");

            migrationBuilder.DropColumn(
                name: "PriceGBP",
                table: "cryptos");
        }
    }
}
