using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace aqua_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RII_PASSWORD_RESET_REQUEST",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_RII_PASSWORD_RESET_REQUEST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_PERMISSION_DEFINITIONS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_RII_PERMISSION_DEFINITIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_PERMISSION_GROUP_PERMISSIONS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGroupId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionDefinitionId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RII_PERMISSION_GROUP_PERMISSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_PERMISSION_GROUP_PERMISSIONS_RII_PERMISSION_DEFINITIONS_PermissionDefinitionId",
                        column: x => x.PermissionDefinitionId,
                        principalTable: "RII_PERMISSION_DEFINITIONS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_PERMISSION_GROUPS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsSystemAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_RII_PERMISSION_GROUPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_SMTP_SETTING",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Host = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    EnableSsl = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordEncrypted = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FromEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FromName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Timeout = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_SMTP_SETTING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_STOCK",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpStockCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UreticiKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrupKodu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrupAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Kod1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod1Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Kod2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod2Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Kod3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod3Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Kod4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod4Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Kod5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Kod5Adi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BranchCode = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                    table.PrimaryKey("PK_RII_STOCK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_STOCK_DETAIL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    HtmlDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalSpecsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_RII_STOCK_DETAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_STOCK_DETAIL_RII_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RII_STOCK_IMAGE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                    table.PrimaryKey("PK_RII_STOCK_IMAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_STOCK_IMAGE_RII_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RII_STOCK_RELATION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    RelatedStockId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_RII_STOCK_RELATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_STOCK_RELATION_RII_STOCK_RelatedStockId",
                        column: x => x.RelatedStockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RII_STOCK_RELATION_RII_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "RII_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_AUTHORITY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_RII_USER_AUTHORITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_USERS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_RII_USERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USER_AUTHORITY_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RII_USER_AUTHORITY",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_DETAIL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: true),
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
                    table.PrimaryKey("PK_RII_USER_DETAIL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USER_DETAIL_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DETAIL_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DETAIL_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DETAIL_RII_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_PERMISSION_GROUPS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionGroupId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_RII_USER_PERMISSION_GROUPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USER_PERMISSION_GROUPS_RII_PERMISSION_GROUPS_PermissionGroupId",
                        column: x => x.PermissionGroupId,
                        principalTable: "RII_PERMISSION_GROUPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_PERMISSION_GROUPS_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_PERMISSION_GROUPS_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_PERMISSION_GROUPS_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_PERMISSION_GROUPS_RII_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_SESSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_RII_USER_SESSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "RII_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RII_PERMISSION_DEFINITIONS",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "dashboard.view", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, true, false, "Dashboard View", null, null },
                    { 2L, "customers.view", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, true, false, "Customers View", null, null },
                    { 3L, "salesmen360.view", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, true, false, "Salesmen 360 View", null, null },
                    { 4L, "customer360.view", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, true, false, "Customer 360 View", null, null },
                    { 5L, "powerbi.view", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, true, false, "Power BI View", null, null }
                });

            migrationBuilder.InsertData(
                table: "RII_PERMISSION_GROUPS",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "IsDeleted", "IsSystemAdmin", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1L, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Full system access", true, false, true, "System Admin", null, null });

            migrationBuilder.InsertData(
                table: "RII_USER_AUTHORITY",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, "User", null, null },
                    { 2L, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, "Manager", null, null },
                    { 3L, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, "Admin", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RII_PASSWORD_RESET_REQUEST_CreatedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PASSWORD_RESET_REQUEST_DeletedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PASSWORD_RESET_REQUEST_UpdatedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PASSWORD_RESET_REQUEST_UserId",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDefinitions_Code",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionDefinitions_IsDeleted",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_DEFINITIONS_CreatedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_DEFINITIONS_DeletedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_DEFINITIONS_UpdatedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupPermission_GroupId_DefinitionId",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                columns: new[] { "PermissionGroupId", "PermissionDefinitionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupPermission_IsDeleted",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUP_PERMISSIONS_CreatedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUP_PERMISSIONS_DeletedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUP_PERMISSIONS_PermissionDefinitionId",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "PermissionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUP_PERMISSIONS_UpdatedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_IsDeleted",
                table: "RII_PERMISSION_GROUPS",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_Name",
                table: "RII_PERMISSION_GROUPS",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUPS_CreatedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUPS_DeletedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PERMISSION_GROUPS_UpdatedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SMTP_SETTING_CreatedByUserId",
                table: "RII_SMTP_SETTING",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SMTP_SETTING_DeletedByUserId",
                table: "RII_SMTP_SETTING",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SMTP_SETTING_UpdatedByUserId",
                table: "RII_SMTP_SETTING",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_CreatedBy",
                table: "RII_STOCK",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_DeletedBy",
                table: "RII_STOCK",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_UpdatedBy",
                table: "RII_STOCK",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ErpStockCode",
                table: "RII_STOCK",
                column: "ErpStockCode");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IsDeleted",
                table: "RII_STOCK",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_StockName",
                table: "RII_STOCK",
                column: "StockName");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_DETAIL_CreatedBy",
                table: "RII_STOCK_DETAIL",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_DETAIL_DeletedBy",
                table: "RII_STOCK_DETAIL",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_DETAIL_UpdatedBy",
                table: "RII_STOCK_DETAIL",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockDetail_IsDeleted",
                table: "RII_STOCK_DETAIL",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StockDetail_StockId",
                table: "RII_STOCK_DETAIL",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_IMAGE_CreatedBy",
                table: "RII_STOCK_IMAGE",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_IMAGE_DeletedBy",
                table: "RII_STOCK_IMAGE",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_IMAGE_UpdatedBy",
                table: "RII_STOCK_IMAGE",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockImage_IsDeleted",
                table: "RII_STOCK_IMAGE",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StockImage_StockId",
                table: "RII_STOCK_IMAGE",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_RELATION_CreatedBy",
                table: "RII_STOCK_RELATION",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_RELATION_DeletedBy",
                table: "RII_STOCK_RELATION",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_STOCK_RELATION_UpdatedBy",
                table: "RII_STOCK_RELATION",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelation_IsDeleted",
                table: "RII_STOCK_RELATION",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelation_RelatedStockId",
                table: "RII_STOCK_RELATION",
                column: "RelatedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelation_StockId",
                table: "RII_STOCK_RELATION",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRelation_StockId_RelatedStockId",
                table: "RII_STOCK_RELATION",
                columns: new[] { "StockId", "RelatedStockId" });

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_CreatedBy",
                table: "RII_USER_AUTHORITY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_DeletedBy",
                table: "RII_USER_AUTHORITY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_UpdatedBy",
                table: "RII_USER_AUTHORITY",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthority_IsDeleted",
                table: "RII_USER_AUTHORITY",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthority_Title",
                table: "RII_USER_AUTHORITY",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DETAIL_CreatedBy",
                table: "RII_USER_DETAIL",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DETAIL_DeletedBy",
                table: "RII_USER_DETAIL",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DETAIL_UpdatedBy",
                table: "RII_USER_DETAIL",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_IsDeleted",
                table: "RII_USER_DETAIL",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserId",
                table: "RII_USER_DETAIL",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_PERMISSION_GROUPS_CreatedBy",
                table: "RII_USER_PERMISSION_GROUPS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_PERMISSION_GROUPS_DeletedBy",
                table: "RII_USER_PERMISSION_GROUPS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_PERMISSION_GROUPS_PermissionGroupId",
                table: "RII_USER_PERMISSION_GROUPS",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_PERMISSION_GROUPS_UpdatedBy",
                table: "RII_USER_PERMISSION_GROUPS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionGroup_IsDeleted",
                table: "RII_USER_PERMISSION_GROUPS",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissionGroup_UserId_GroupId",
                table: "RII_USER_PERMISSION_GROUPS",
                columns: new[] { "UserId", "PermissionGroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_CreatedBy",
                table: "RII_USER_SESSION",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_DeletedBy",
                table: "RII_USER_SESSION",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_UpdatedBy",
                table: "RII_USER_SESSION",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_IsDeleted",
                table: "RII_USER_SESSION",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_RevokedAt",
                table: "RII_USER_SESSION",
                column: "RevokedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_SessionId",
                table: "RII_USER_SESSION",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserId",
                table: "RII_USER_SESSION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_CreatedBy",
                table: "RII_USERS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_DeletedBy",
                table: "RII_USERS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_RoleId",
                table: "RII_USERS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_UpdatedBy",
                table: "RII_USERS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "RII_USERS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsDeleted",
                table: "RII_USERS",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "RII_USERS",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PASSWORD_RESET_REQUEST_RII_USERS_CreatedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PASSWORD_RESET_REQUEST_RII_USERS_DeletedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PASSWORD_RESET_REQUEST_RII_USERS_UpdatedBy",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PASSWORD_RESET_REQUEST_RII_USERS_UserId",
                table: "RII_PASSWORD_RESET_REQUEST",
                column: "UserId",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_DEFINITIONS_RII_USERS_CreatedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_DEFINITIONS_RII_USERS_DeletedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_DEFINITIONS_RII_USERS_UpdatedBy",
                table: "RII_PERMISSION_DEFINITIONS",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUP_PERMISSIONS_RII_PERMISSION_GROUPS_PermissionGroupId",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "PermissionGroupId",
                principalTable: "RII_PERMISSION_GROUPS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUP_PERMISSIONS_RII_USERS_CreatedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUP_PERMISSIONS_RII_USERS_DeletedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUP_PERMISSIONS_RII_USERS_UpdatedBy",
                table: "RII_PERMISSION_GROUP_PERMISSIONS",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUPS_RII_USERS_CreatedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUPS_RII_USERS_DeletedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PERMISSION_GROUPS_RII_USERS_UpdatedBy",
                table: "RII_PERMISSION_GROUPS",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SMTP_SETTING_RII_USERS_CreatedByUserId",
                table: "RII_SMTP_SETTING",
                column: "CreatedByUserId",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SMTP_SETTING_RII_USERS_DeletedByUserId",
                table: "RII_SMTP_SETTING",
                column: "DeletedByUserId",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SMTP_SETTING_RII_USERS_UpdatedByUserId",
                table: "RII_SMTP_SETTING",
                column: "UpdatedByUserId",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RII_USERS_CreatedBy",
                table: "RII_STOCK",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RII_USERS_DeletedBy",
                table: "RII_STOCK",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RII_USERS_UpdatedBy",
                table: "RII_STOCK",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_DETAIL_RII_USERS_CreatedBy",
                table: "RII_STOCK_DETAIL",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_DETAIL_RII_USERS_DeletedBy",
                table: "RII_STOCK_DETAIL",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_DETAIL_RII_USERS_UpdatedBy",
                table: "RII_STOCK_DETAIL",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_IMAGE_RII_USERS_CreatedBy",
                table: "RII_STOCK_IMAGE",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_IMAGE_RII_USERS_DeletedBy",
                table: "RII_STOCK_IMAGE",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_IMAGE_RII_USERS_UpdatedBy",
                table: "RII_STOCK_IMAGE",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RELATION_RII_USERS_CreatedBy",
                table: "RII_STOCK_RELATION",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RELATION_RII_USERS_DeletedBy",
                table: "RII_STOCK_RELATION",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_STOCK_RELATION_RII_USERS_UpdatedBy",
                table: "RII_STOCK_RELATION",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_CreatedBy",
                table: "RII_USER_AUTHORITY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_DeletedBy",
                table: "RII_USER_AUTHORITY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_UpdatedBy",
                table: "RII_USER_AUTHORITY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_CreatedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_DeletedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_UpdatedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropTable(
                name: "RII_PASSWORD_RESET_REQUEST");

            migrationBuilder.DropTable(
                name: "RII_PERMISSION_GROUP_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "RII_SMTP_SETTING");

            migrationBuilder.DropTable(
                name: "RII_STOCK_DETAIL");

            migrationBuilder.DropTable(
                name: "RII_STOCK_IMAGE");

            migrationBuilder.DropTable(
                name: "RII_STOCK_RELATION");

            migrationBuilder.DropTable(
                name: "RII_USER_DETAIL");

            migrationBuilder.DropTable(
                name: "RII_USER_PERMISSION_GROUPS");

            migrationBuilder.DropTable(
                name: "RII_USER_SESSION");

            migrationBuilder.DropTable(
                name: "RII_PERMISSION_DEFINITIONS");

            migrationBuilder.DropTable(
                name: "RII_STOCK");

            migrationBuilder.DropTable(
                name: "RII_PERMISSION_GROUPS");

            migrationBuilder.DropTable(
                name: "RII_USERS");

            migrationBuilder.DropTable(
                name: "RII_USER_AUTHORITY");
        }
    }
}
