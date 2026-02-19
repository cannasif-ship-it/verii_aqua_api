using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class AquaModuleInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RII_Cage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CageCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CageName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CapacityCount = table.Column<int>(type: "int", nullable: true),
                    CapacityGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
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
                    table.PrimaryKey("PK_RII_Cage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_Cage_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Cage_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Cage_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_NetOperationType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_RII_NetOperationType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_NetOperationType_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationType_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationType_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
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
                    table.PrimaryKey("PK_RII_Project", x => x.Id);
                    table.CheckConstraint("CK_RII_Project_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Project_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Project_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Project_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_WeatherSeverity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RII_WeatherSeverity", x => x.Id);
                    table.CheckConstraint("CK_RII_WeatherSeverity_Score", "[Score] >= 0");
                    table.ForeignKey(
                        name: "FK_RII_WeatherSeverity_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeatherSeverity_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeatherSeverity_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_WeatherType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_RII_WeatherType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_WeatherType_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeatherType_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeatherType_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_Feeding",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    FeedingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeedingDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    FeedingSlot = table.Column<byte>(type: "tinyint", nullable: false),
                    SourceType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FeedingDateOnly = table.Column<DateTime>(type: "date", nullable: false, computedColumnSql: "CAST([FeedingDate] AS date)", stored: true),
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
                    table.PrimaryKey("PK_RII_Feeding", x => x.Id);
                    table.CheckConstraint("CK_RII_Feeding_Slot", "[FeedingSlot] IN (0,1)");
                    table.CheckConstraint("CK_RII_Feeding_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Feeding_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Feeding_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Feeding_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Feeding_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_GoodsReceipt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    ReceiptNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    WarehouseId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_RII_GoodsReceipt", x => x.Id);
                    table.CheckConstraint("CK_RII_GoodsReceipt_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceipt_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceipt_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceipt_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceipt_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_Mortality",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    MortalityDate = table.Column<DateTime>(type: "date", nullable: false),
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
                    table.PrimaryKey("PK_RII_Mortality", x => x.Id);
                    table.CheckConstraint("CK_RII_Mortality_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Mortality_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Mortality_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Mortality_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Mortality_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_NetOperation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OperationNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_NetOperation", x => x.Id);
                    table.CheckConstraint("CK_RII_NetOperation_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_NetOperation_RII_NetOperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "RII_NetOperationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperation_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperation_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperation_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperation_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_ProjectCage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    CageId = table.Column<long>(type: "bigint", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
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
                    table.PrimaryKey("PK_RII_ProjectCage", x => x.Id);
                    table.CheckConstraint("CK_RII_ProjectCage_AssignRelease", "[ReleasedDate] IS NULL OR [ReleasedDate] >= [AssignedDate]");
                    table.ForeignKey(
                        name: "FK_RII_ProjectCage_RII_Cage_CageId",
                        column: x => x.CageId,
                        principalTable: "RII_Cage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ProjectCage_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ProjectCage_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ProjectCage_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ProjectCage_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_StockConvert",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ConvertNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConvertDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_StockConvert", x => x.Id);
                    table.CheckConstraint("CK_RII_StockConvert_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_StockConvert_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvert_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvert_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvert_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_Transfer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    TransferNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_Transfer", x => x.Id);
                    table.CheckConstraint("CK_RII_Transfer_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Transfer_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Transfer_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Transfer_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Transfer_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_Weighing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    WeighingNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WeighingDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_Weighing", x => x.Id);
                    table.CheckConstraint("CK_RII_Weighing_Status", "[Status] IN (0,1,2)");
                    table.ForeignKey(
                        name: "FK_RII_Weighing_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Weighing_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Weighing_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_Weighing_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_DailyWeather",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    WeatherDate = table.Column<DateTime>(type: "date", nullable: false),
                    WeatherTypeId = table.Column<long>(type: "bigint", nullable: false),
                    WeatherSeverityId = table.Column<long>(type: "bigint", nullable: false),
                    TemperatureC = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    WindKnot = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
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
                    table.PrimaryKey("PK_RII_DailyWeather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_WeatherSeverity_WeatherSeverityId",
                        column: x => x.WeatherSeverityId,
                        principalTable: "RII_WeatherSeverity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DailyWeather_RII_WeatherType_WeatherTypeId",
                        column: x => x.WeatherTypeId,
                        principalTable: "RII_WeatherType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_FeedingLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedingId = table.Column<long>(type: "bigint", nullable: false),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    QtyUnit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    GramPerUnit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    TotalGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_FeedingLine", x => x.Id);
                    table.CheckConstraint("CK_RII_FeedingLine_Positive", "[QtyUnit] > 0 AND [GramPerUnit] > 0 AND [TotalGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_FeedingLine_RII_Feeding_FeedingId",
                        column: x => x.FeedingId,
                        principalTable: "RII_Feeding",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingLine_RII_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_BatchCageBalance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    LiveCount = table.Column<int>(type: "int", nullable: false),
                    AverageGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    BiomassGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    AsOfDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_BatchCageBalance", x => x.Id);
                    table.CheckConstraint("CK_RII_BatchCageBalance_NonNegative", "[LiveCount] >= 0 AND [AverageGram] >= 0 AND [BiomassGram] >= 0");
                    table.ForeignKey(
                        name: "FK_RII_BatchCageBalance_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchCageBalance_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchCageBalance_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchCageBalance_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_BatchMovement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: true),
                    MovementDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    MovementType = table.Column<byte>(type: "tinyint", nullable: false),
                    SignedCount = table.Column<int>(type: "int", nullable: false),
                    SignedBiomassGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    ReferenceTable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RII_BatchMovement", x => x.Id);
                    table.CheckConstraint("CK_RII_BatchMovement_MovementType", "[MovementType] IN (0,1,2,3,4,5)");
                    table.ForeignKey(
                        name: "FK_RII_BatchMovement_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchMovement_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchMovement_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_BatchMovement_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_FeedingDistribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedingLineId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    FeedGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_FeedingDistribution", x => x.Id);
                    table.CheckConstraint("CK_RII_FeedingDistribution_FeedGram", "[FeedGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_FeedingDistribution_RII_FeedingLine_FeedingLineId",
                        column: x => x.FeedingLineId,
                        principalTable: "RII_FeedingLine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingDistribution_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingDistribution_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingDistribution_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FeedingDistribution_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_FishBatch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    BatchCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FishStockId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentAverageGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    SourceGoodsReceiptLineId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_RII_FishBatch", x => x.Id);
                    table.CheckConstraint("CK_RII_FishBatch_CurrentAverageGram", "[CurrentAverageGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_FishBatch_RII_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "RII_Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FishBatch_RII_STOCK_FishStockId",
                        column: x => x.FishStockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FishBatch_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FishBatch_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_FishBatch_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_GoodsReceiptLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsReceiptId = table.Column<long>(type: "bigint", nullable: false),
                    ItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    QtyUnit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    GramPerUnit = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    TotalGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    FishCount = table.Column<int>(type: "int", nullable: true),
                    FishAverageGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    FishTotalGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_RII_GoodsReceiptLine", x => x.Id);
                    table.CheckConstraint("CK_RII_GoodsReceiptLine_ItemType", "[ItemType] IN (0,1)");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_GoodsReceipt_GoodsReceiptId",
                        column: x => x.GoodsReceiptId,
                        principalTable: "RII_GoodsReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_MortalityLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MortalityId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    DeadCount = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RII_MortalityLine", x => x.Id);
                    table.CheckConstraint("CK_RII_MortalityLine_DeadCount", "[DeadCount] > 0");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_Mortality_MortalityId",
                        column: x => x.MortalityId,
                        principalTable: "RII_Mortality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_MortalityLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_NetOperationLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetOperationId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    UnitGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: true),
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
                    table.PrimaryKey("PK_RII_NetOperationLine", x => x.Id);
                    table.CheckConstraint("CK_RII_NetOperationLine_Quantity", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_NetOperation_NetOperationId",
                        column: x => x.NetOperationId,
                        principalTable: "RII_NetOperation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_NetOperationLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_StockConvertLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockConvertId = table.Column<long>(type: "bigint", nullable: false),
                    FromFishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ToFishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    FromProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    ToProjectCageId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RII_StockConvertLine", x => x.Id);
                    table.CheckConstraint("CK_RII_StockConvertLine_Positive", "[FishCount] > 0 AND [AverageGram] > 0 AND [BiomassGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_FishBatch_FromFishBatchId",
                        column: x => x.FromFishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_FishBatch_ToFishBatchId",
                        column: x => x.ToFishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_ProjectCage_FromProjectCageId",
                        column: x => x.FromProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_ProjectCage_ToProjectCageId",
                        column: x => x.ToProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_StockConvert_StockConvertId",
                        column: x => x.StockConvertId,
                        principalTable: "RII_StockConvert",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_StockConvertLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_TransferLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    FromProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    ToProjectCageId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RII_TransferLine", x => x.Id);
                    table.CheckConstraint("CK_RII_TransferLine_FromToDiff", "[FromProjectCageId] <> [ToProjectCageId]");
                    table.CheckConstraint("CK_RII_TransferLine_Positive", "[FishCount] > 0 AND [AverageGram] > 0 AND [BiomassGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_ProjectCage_FromProjectCageId",
                        column: x => x.FromProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_ProjectCage_ToProjectCageId",
                        column: x => x.ToProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_Transfer_TransferId",
                        column: x => x.TransferId,
                        principalTable: "RII_Transfer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TransferLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_WeighingLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeighingId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    MeasuredCount = table.Column<int>(type: "int", nullable: false),
                    MeasuredAverageGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
                    MeasuredBiomassGram = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 3, nullable: false),
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
                    table.PrimaryKey("PK_RII_WeighingLine", x => x.Id);
                    table.CheckConstraint("CK_RII_WeighingLine_Positive", "[MeasuredCount] > 0 AND [MeasuredAverageGram] > 0 AND [MeasuredBiomassGram] > 0");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_WeighingLine_RII_Weighing_WeighingId",
                        column: x => x.WeighingId,
                        principalTable: "RII_Weighing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_GoodsReceiptFishDistribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodsReceiptLineId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectCageId = table.Column<long>(type: "bigint", nullable: false),
                    FishBatchId = table.Column<long>(type: "bigint", nullable: false),
                    FishCount = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RII_GoodsReceiptFishDistribution", x => x.Id);
                    table.CheckConstraint("CK_RII_GoodsReceiptFishDistribution_Count", "[FishCount] > 0");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_FishBatch_FishBatchId",
                        column: x => x.FishBatchId,
                        principalTable: "RII_FishBatch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_GoodsReceiptLine_GoodsReceiptLineId",
                        column: x => x.GoodsReceiptLineId,
                        principalTable: "RII_GoodsReceiptLine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_ProjectCage_ProjectCageId",
                        column: x => x.ProjectCageId,
                        principalTable: "RII_ProjectCage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_GoodsReceiptFishDistribution_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchCageBalance_CreatedBy",
                table: "RII_BatchCageBalance",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchCageBalance_DeletedBy",
                table: "RII_BatchCageBalance",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchCageBalance_ProjectCageId",
                table: "RII_BatchCageBalance",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchCageBalance_UpdatedBy",
                table: "RII_BatchCageBalance",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_BatchCageBalance_BatchCage_Active",
                table: "RII_BatchCageBalance",
                columns: new[] { "FishBatchId", "ProjectCageId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchMovement_BatchDate",
                table: "RII_BatchMovement",
                columns: new[] { "FishBatchId", "MovementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchMovement_CreatedBy",
                table: "RII_BatchMovement",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchMovement_DeletedBy",
                table: "RII_BatchMovement",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchMovement_ProjectCageId",
                table: "RII_BatchMovement",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_BatchMovement_UpdatedBy",
                table: "RII_BatchMovement",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Cage_CreatedBy",
                table: "RII_Cage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Cage_DeletedBy",
                table: "RII_Cage",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Cage_UpdatedBy",
                table: "RII_Cage",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Cage_CageCode_Active",
                table: "RII_Cage",
                column: "CageCode",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DailyWeather_CreatedBy",
                table: "RII_DailyWeather",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DailyWeather_DeletedBy",
                table: "RII_DailyWeather",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DailyWeather_UpdatedBy",
                table: "RII_DailyWeather",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DailyWeather_WeatherSeverityId",
                table: "RII_DailyWeather",
                column: "WeatherSeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DailyWeather_WeatherTypeId",
                table: "RII_DailyWeather",
                column: "WeatherTypeId");

            migrationBuilder.CreateIndex(
                name: "UX_RII_DailyWeather_ProjectDate_Active",
                table: "RII_DailyWeather",
                columns: new[] { "ProjectId", "WeatherDate" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Feeding_CreatedBy",
                table: "RII_Feeding",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Feeding_DeletedBy",
                table: "RII_Feeding",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Feeding_UpdatedBy",
                table: "RII_Feeding",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Feeding_FeedingNo_Active",
                table: "RII_Feeding",
                column: "FeedingNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Feeding_Project_Date_Slot_Active",
                table: "RII_Feeding",
                columns: new[] { "ProjectId", "FeedingDateOnly", "FeedingSlot" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_CreatedBy",
                table: "RII_FeedingDistribution",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_DeletedBy",
                table: "RII_FeedingDistribution",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_FeedingLineId",
                table: "RII_FeedingDistribution",
                column: "FeedingLineId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_FishBatchId",
                table: "RII_FeedingDistribution",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_ProjectCageId",
                table: "RII_FeedingDistribution",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingDistribution_UpdatedBy",
                table: "RII_FeedingDistribution",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingLine_CreatedBy",
                table: "RII_FeedingLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingLine_DeletedBy",
                table: "RII_FeedingLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingLine_FeedingId",
                table: "RII_FeedingLine",
                column: "FeedingId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingLine_StockId",
                table: "RII_FeedingLine",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FeedingLine_UpdatedBy",
                table: "RII_FeedingLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FishBatch_CreatedBy",
                table: "RII_FishBatch",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FishBatch_DeletedBy",
                table: "RII_FishBatch",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FishBatch_FishStockId",
                table: "RII_FishBatch",
                column: "FishStockId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FishBatch_SourceGoodsReceiptLineId",
                table: "RII_FishBatch",
                column: "SourceGoodsReceiptLineId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_FishBatch_UpdatedBy",
                table: "RII_FishBatch",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_FishBatch_Project_BatchCode_Active",
                table: "RII_FishBatch",
                columns: new[] { "ProjectId", "BatchCode" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceipt_CreatedBy",
                table: "RII_GoodsReceipt",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceipt_DeletedBy",
                table: "RII_GoodsReceipt",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceipt_ProjectId",
                table: "RII_GoodsReceipt",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceipt_UpdatedBy",
                table: "RII_GoodsReceipt",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_GoodsReceipt_ReceiptNo_Active",
                table: "RII_GoodsReceipt",
                column: "ReceiptNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptFishDistribution_CreatedBy",
                table: "RII_GoodsReceiptFishDistribution",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptFishDistribution_DeletedBy",
                table: "RII_GoodsReceiptFishDistribution",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptFishDistribution_FishBatchId",
                table: "RII_GoodsReceiptFishDistribution",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptFishDistribution_ProjectCageId",
                table: "RII_GoodsReceiptFishDistribution",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptFishDistribution_UpdatedBy",
                table: "RII_GoodsReceiptFishDistribution",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_GoodsReceiptFishDistribution_LineCage_Active",
                table: "RII_GoodsReceiptFishDistribution",
                columns: new[] { "GoodsReceiptLineId", "ProjectCageId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_CreatedBy",
                table: "RII_GoodsReceiptLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_DeletedBy",
                table: "RII_GoodsReceiptLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_FishBatchId",
                table: "RII_GoodsReceiptLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_GoodsReceiptId",
                table: "RII_GoodsReceiptLine",
                column: "GoodsReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_StockId",
                table: "RII_GoodsReceiptLine",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_GoodsReceiptLine_UpdatedBy",
                table: "RII_GoodsReceiptLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Mortality_CreatedBy",
                table: "RII_Mortality",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Mortality_DeletedBy",
                table: "RII_Mortality",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Mortality_UpdatedBy",
                table: "RII_Mortality",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Mortality_ProjectDate_Active",
                table: "RII_Mortality",
                columns: new[] { "ProjectId", "MortalityDate" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_CreatedBy",
                table: "RII_MortalityLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_DeletedBy",
                table: "RII_MortalityLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_FishBatchId",
                table: "RII_MortalityLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_MortalityId",
                table: "RII_MortalityLine",
                column: "MortalityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_ProjectCageId",
                table: "RII_MortalityLine",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_MortalityLine_UpdatedBy",
                table: "RII_MortalityLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperation_CreatedBy",
                table: "RII_NetOperation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperation_DeletedBy",
                table: "RII_NetOperation",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperation_OperationTypeId",
                table: "RII_NetOperation",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperation_ProjectId",
                table: "RII_NetOperation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperation_UpdatedBy",
                table: "RII_NetOperation",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_NetOperation_OperationNo_Active",
                table: "RII_NetOperation",
                column: "OperationNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_CreatedBy",
                table: "RII_NetOperationLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_DeletedBy",
                table: "RII_NetOperationLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_FishBatchId",
                table: "RII_NetOperationLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_NetOperationId",
                table: "RII_NetOperationLine",
                column: "NetOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_ProjectCageId",
                table: "RII_NetOperationLine",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationLine_UpdatedBy",
                table: "RII_NetOperationLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationType_CreatedBy",
                table: "RII_NetOperationType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationType_DeletedBy",
                table: "RII_NetOperationType",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_NetOperationType_UpdatedBy",
                table: "RII_NetOperationType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_NetOperationType_Code_Active",
                table: "RII_NetOperationType",
                column: "Code",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Project_CreatedBy",
                table: "RII_Project",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Project_DeletedBy",
                table: "RII_Project",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Project_UpdatedBy",
                table: "RII_Project",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Project_ProjectCode_Active",
                table: "RII_Project",
                column: "ProjectCode",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ProjectCage_CreatedBy",
                table: "RII_ProjectCage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ProjectCage_DeletedBy",
                table: "RII_ProjectCage",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ProjectCage_ProjectId",
                table: "RII_ProjectCage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ProjectCage_UpdatedBy",
                table: "RII_ProjectCage",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_ProjectCage_CageId_ActiveAssignment",
                table: "RII_ProjectCage",
                column: "CageId",
                unique: true,
                filter: "[ReleasedDate] IS NULL AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvert_CreatedBy",
                table: "RII_StockConvert",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvert_DeletedBy",
                table: "RII_StockConvert",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvert_ProjectId",
                table: "RII_StockConvert",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvert_UpdatedBy",
                table: "RII_StockConvert",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_StockConvert_ConvertNo_Active",
                table: "RII_StockConvert",
                column: "ConvertNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_CreatedBy",
                table: "RII_StockConvertLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_DeletedBy",
                table: "RII_StockConvertLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_FromFishBatchId",
                table: "RII_StockConvertLine",
                column: "FromFishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_FromProjectCageId",
                table: "RII_StockConvertLine",
                column: "FromProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_StockConvertId",
                table: "RII_StockConvertLine",
                column: "StockConvertId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_ToFishBatchId",
                table: "RII_StockConvertLine",
                column: "ToFishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_ToProjectCageId",
                table: "RII_StockConvertLine",
                column: "ToProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_StockConvertLine_UpdatedBy",
                table: "RII_StockConvertLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Transfer_CreatedBy",
                table: "RII_Transfer",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Transfer_DeletedBy",
                table: "RII_Transfer",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Transfer_ProjectId",
                table: "RII_Transfer",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Transfer_UpdatedBy",
                table: "RII_Transfer",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Transfer_TransferNo_Active",
                table: "RII_Transfer",
                column: "TransferNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_CreatedBy",
                table: "RII_TransferLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_DeletedBy",
                table: "RII_TransferLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_FishBatchId",
                table: "RII_TransferLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_FromProjectCageId",
                table: "RII_TransferLine",
                column: "FromProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_ToProjectCageId",
                table: "RII_TransferLine",
                column: "ToProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_TransferId",
                table: "RII_TransferLine",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TransferLine_UpdatedBy",
                table: "RII_TransferLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherSeverity_CreatedBy",
                table: "RII_WeatherSeverity",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherSeverity_DeletedBy",
                table: "RII_WeatherSeverity",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherSeverity_UpdatedBy",
                table: "RII_WeatherSeverity",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_WeatherSeverity_Code_Active",
                table: "RII_WeatherSeverity",
                column: "Code",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherType_CreatedBy",
                table: "RII_WeatherType",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherType_DeletedBy",
                table: "RII_WeatherType",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeatherType_UpdatedBy",
                table: "RII_WeatherType",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_WeatherType_Code_Active",
                table: "RII_WeatherType",
                column: "Code",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Weighing_CreatedBy",
                table: "RII_Weighing",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Weighing_DeletedBy",
                table: "RII_Weighing",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Weighing_ProjectId",
                table: "RII_Weighing",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_Weighing_UpdatedBy",
                table: "RII_Weighing",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "UX_RII_Weighing_WeighingNo_Active",
                table: "RII_Weighing",
                column: "WeighingNo",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_CreatedBy",
                table: "RII_WeighingLine",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_DeletedBy",
                table: "RII_WeighingLine",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_FishBatchId",
                table: "RII_WeighingLine",
                column: "FishBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_ProjectCageId",
                table: "RII_WeighingLine",
                column: "ProjectCageId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_UpdatedBy",
                table: "RII_WeighingLine",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_WeighingLine_WeighingId",
                table: "RII_WeighingLine",
                column: "WeighingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_BatchCageBalance_RII_FishBatch_FishBatchId",
                table: "RII_BatchCageBalance",
                column: "FishBatchId",
                principalTable: "RII_FishBatch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_BatchMovement_RII_FishBatch_FishBatchId",
                table: "RII_BatchMovement",
                column: "FishBatchId",
                principalTable: "RII_FishBatch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_FeedingDistribution_RII_FishBatch_FishBatchId",
                table: "RII_FeedingDistribution",
                column: "FishBatchId",
                principalTable: "RII_FishBatch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_FishBatch_RII_GoodsReceiptLine_SourceGoodsReceiptLineId",
                table: "RII_FishBatch",
                column: "SourceGoodsReceiptLineId",
                principalTable: "RII_GoodsReceiptLine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RII_GoodsReceiptLine_RII_FishBatch_FishBatchId",
                table: "RII_GoodsReceiptLine");

            migrationBuilder.DropTable(
                name: "RII_BatchCageBalance");

            migrationBuilder.DropTable(
                name: "RII_BatchMovement");

            migrationBuilder.DropTable(
                name: "RII_DailyWeather");

            migrationBuilder.DropTable(
                name: "RII_FeedingDistribution");

            migrationBuilder.DropTable(
                name: "RII_GoodsReceiptFishDistribution");

            migrationBuilder.DropTable(
                name: "RII_MortalityLine");

            migrationBuilder.DropTable(
                name: "RII_NetOperationLine");

            migrationBuilder.DropTable(
                name: "RII_StockConvertLine");

            migrationBuilder.DropTable(
                name: "RII_TransferLine");

            migrationBuilder.DropTable(
                name: "RII_WeighingLine");

            migrationBuilder.DropTable(
                name: "RII_WeatherSeverity");

            migrationBuilder.DropTable(
                name: "RII_WeatherType");

            migrationBuilder.DropTable(
                name: "RII_FeedingLine");

            migrationBuilder.DropTable(
                name: "RII_Mortality");

            migrationBuilder.DropTable(
                name: "RII_NetOperation");

            migrationBuilder.DropTable(
                name: "RII_StockConvert");

            migrationBuilder.DropTable(
                name: "RII_Transfer");

            migrationBuilder.DropTable(
                name: "RII_ProjectCage");

            migrationBuilder.DropTable(
                name: "RII_Weighing");

            migrationBuilder.DropTable(
                name: "RII_Feeding");

            migrationBuilder.DropTable(
                name: "RII_NetOperationType");

            migrationBuilder.DropTable(
                name: "RII_Cage");

            migrationBuilder.DropTable(
                name: "RII_FishBatch");

            migrationBuilder.DropTable(
                name: "RII_GoodsReceiptLine");

            migrationBuilder.DropTable(
                name: "RII_GoodsReceipt");

            migrationBuilder.DropTable(
                name: "RII_Project");
        }
    }
}
