using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchMovementStockContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FromAverageGram",
                table: "RII_BatchMovement",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FromProjectCageId",
                table: "RII_BatchMovement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FromStockId",
                table: "RII_BatchMovement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ToAverageGram",
                table: "RII_BatchMovement",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ToProjectCageId",
                table: "RII_BatchMovement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ToStockId",
                table: "RII_BatchMovement",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromAverageGram",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "FromProjectCageId",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "FromStockId",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "ToAverageGram",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "ToProjectCageId",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "ToStockId",
                table: "RII_BatchMovement");
        }
    }
}
