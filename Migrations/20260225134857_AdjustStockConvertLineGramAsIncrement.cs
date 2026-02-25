using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class AdjustStockConvertLineGramAsIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_StockConvertLine_Positive",
                table: "RII_StockConvertLine");

            migrationBuilder.AddColumn<decimal>(
                name: "NewAverageGram",
                table: "RII_StockConvertLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_StockConvertLine_Positive",
                table: "RII_StockConvertLine",
                sql: "[FishCount] > 0 AND [AverageGram] > 0 AND [NewAverageGram] >= 0 AND [BiomassGram] > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_StockConvertLine_Positive",
                table: "RII_StockConvertLine");

            migrationBuilder.DropColumn(
                name: "NewAverageGram",
                table: "RII_StockConvertLine");

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_StockConvertLine_Positive",
                table: "RII_StockConvertLine",
                sql: "[FishCount] > 0 AND [AverageGram] > 0 AND [BiomassGram] > 0");
        }
    }
}
