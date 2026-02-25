using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentAndCloseProjectOnFullShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_NetOperationLine_Quantity",
                table: "RII_NetOperationLine");

            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RII_NetOperationLine");

            migrationBuilder.DropColumn(
                name: "UnitGram",
                table: "RII_NetOperationLine");

            migrationBuilder.CreateTable(
                name: "RII_Shipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ShipmentNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    TargetWarehouse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_Shipment", x => x.Id);
                    table.CheckConstraint("CK_RII_Shipment_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Shipment_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Shipment_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Shipment_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Shipment_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_ShipmentLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    FromProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    FishCount = table.Column<int>(type: "int", nullable: false),
                    AverageGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    BiomassGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_ShipmentLine", x => x.Id);
                    table.CheckConstraint("CK_RII_ShipmentLine_Positive", "[FishCount] > 0 AND [AverageGram] >= 0 AND [BiomassGram] >= 0");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_ProjectCage_FromProjectCageId",
                        column: x => x.FromProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "RII_Shipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ShipmentLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement",
                sql: "[MovementType] IN (0,1,2,3,4,5,6)");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Shipment_CreatedBy",
                table: "RII_Shipment",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Shipment_DeletedBy",
                table: "RII_Shipment",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Shipment_ProjectId",
                table: "RII_Shipment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Shipment_UpdatedBy",
                table: "RII_Shipment",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Shipment_ShipmentNo_Active",
                table: "RII_Shipment",
                column: "ShipmentNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_CreatedBy",
                table: "RII_ShipmentLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_DeletedBy",
                table: "RII_ShipmentLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_FishBatchId",
                table: "RII_ShipmentLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_FromProjectCageId",
                table: "RII_ShipmentLine",
                column: "FromProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_ShipmentId",
                table: "RII_ShipmentLine",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ShipmentLine_UpdatedBy",
                table: "RII_ShipmentLine",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_ShipmentLine");

            migrationBuilder.DropTable(
                name: "RII_Shipment");

            migrationBuilder.DropCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "RII_NetOperationLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitGram",
                table: "RII_NetOperationLine",
                type: "decimal(18,6)",
                precision: 18,
                scale: 3,
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_NetOperationLine_Quantity",
                table: "RII_NetOperationLine",
                sql: "[Quantity] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_RII_BatchMovement_MovementType",
                table: "RII_BatchMovement",
                sql: "[MovementType] IN (0,1,2,3,4,5)");
        }
    }
}
