using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchMovementFeedAndActor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement");

            migrationBuilder.AddColumn<long>(
                name: "ActorUserId",
                table: "RII_BatchMovement",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FeedGram",
                table: "RII_BatchMovement",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement",
                sql: "[MovementType] IN (0,1,2,3,4,5,6,7)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "ActorUserId",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "FeedGram",
                table: "RII_BatchMovement");

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement",
                sql: "[MovementType] IN (0,1,2,3,4,5,6)");
        }
    }
}
