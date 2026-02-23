SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/*
AQUA Domain Schema (RII_ prefix)
- Soft delete architecture
- No cascade delete
- Filtered unique indexes (IsDeleted = 0)
- Existing table reference: RII_STOCK(Id)
*/

/* =========================================================
   MASTER: PROJECT / CAGE / PROJECTCAGE
   ========================================================= */
CREATE TABLE dbo.RII_Project (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectCode nvarchar(50) NOT NULL,
    ProjectName nvarchar(200) NOT NULL,
    StartDate date NOT NULL,
    EndDate date NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_Project_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Project_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Project_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Project PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT CK_RII_Project_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_Project_ProjectCode_Active
ON dbo.RII_Project(ProjectCode)
WHERE IsDeleted = 0;
GO

CREATE INDEX IX_RII_Project_Status ON dbo.RII_Project(Status);
GO

CREATE TABLE dbo.RII_Cage (
    Id bigint IDENTITY(1,1) NOT NULL,
    CageCode nvarchar(50) NOT NULL,
    CageName nvarchar(200) NOT NULL,
    CapacityCount int NULL,
    CapacityGram decimal(18,3) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Cage_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Cage_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Cage PRIMARY KEY CLUSTERED (Id)
);
GO

CREATE UNIQUE INDEX UX_RII_Cage_CageCode_Active
ON dbo.RII_Cage(CageCode)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_ProjectCage (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    CageId bigint NOT NULL,
    AssignedDate datetime2(3) NOT NULL,
    ReleasedDate datetime2(3) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_ProjectCage_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_ProjectCage_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_ProjectCage PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_ProjectCage_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT FK_RII_ProjectCage_Cage FOREIGN KEY(CageId) REFERENCES dbo.RII_Cage(Id),
    CONSTRAINT CK_RII_ProjectCage_AssignRelease CHECK (ReleasedDate IS NULL OR ReleasedDate >= AssignedDate)
);
GO

CREATE UNIQUE INDEX UX_RII_ProjectCage_CageId_ActiveAssignment
ON dbo.RII_ProjectCage(CageId)
WHERE ReleasedDate IS NULL AND IsDeleted = 0;
GO

CREATE INDEX IX_RII_ProjectCage_ProjectId ON dbo.RII_ProjectCage(ProjectId);
CREATE INDEX IX_RII_ProjectCage_CageId ON dbo.RII_ProjectCage(CageId);
GO

/* =========================================================
   FISH BATCH + BALANCE
   ========================================================= */
CREATE TABLE dbo.RII_FishBatch (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    BatchCode nvarchar(50) NOT NULL,
    FishStockId bigint NOT NULL,
    CurrentAverageGram decimal(18,3) NOT NULL,
    StartDate datetime2(3) NOT NULL,
    SourceGoodsReceiptLineId bigint NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_FishBatch_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_FishBatch_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_FishBatch PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_FishBatch_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT FK_RII_FishBatch_Stock FOREIGN KEY(FishStockId) REFERENCES dbo.RII_STOCK(Id),
    CONSTRAINT CK_RII_FishBatch_CurrentAverageGram CHECK (CurrentAverageGram > 0)
);
GO

CREATE UNIQUE INDEX UX_RII_FishBatch_Project_BatchCode_Active
ON dbo.RII_FishBatch(ProjectId, BatchCode)
WHERE IsDeleted = 0;
GO

CREATE INDEX IX_RII_FishBatch_ProjectId ON dbo.RII_FishBatch(ProjectId);
GO

CREATE TABLE dbo.RII_BatchCageBalance (
    Id bigint IDENTITY(1,1) NOT NULL,
    FishBatchId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    LiveCount int NOT NULL,
    AverageGram decimal(18,3) NOT NULL,
    BiomassGram decimal(18,3) NOT NULL,
    AsOfDate datetime2(3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_BatchCageBalance_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_BatchCageBalance_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_BatchCageBalance PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_BatchCageBalance_FishBatch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_BatchCageBalance_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_BatchCageBalance_NonNegative CHECK (LiveCount >= 0 AND AverageGram >= 0 AND BiomassGram >= 0)
);
GO

CREATE UNIQUE INDEX UX_RII_BatchCageBalance_BatchCage_Active
ON dbo.RII_BatchCageBalance(FishBatchId, ProjectCageId)
WHERE IsDeleted = 0;
GO

/* =========================================================
   GOODS RECEIPT
   ========================================================= */
CREATE TABLE dbo.RII_GoodsReceipt (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NULL,
    ReceiptNo nvarchar(50) NOT NULL,
    ReceiptDate datetime2(3) NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_GoodsReceipt_Status DEFAULT (0),
    SupplierId bigint NULL,
    WarehouseId bigint NULL,
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_GoodsReceipt_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_GoodsReceipt_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_GoodsReceipt PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_GoodsReceipt_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_GoodsReceipt_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_GoodsReceipt_ReceiptNo_Active
ON dbo.RII_GoodsReceipt(ReceiptNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_GoodsReceiptLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    GoodsReceiptId bigint NOT NULL,
    ItemType tinyint NOT NULL,
    StockId bigint NOT NULL,
    QtyUnit decimal(18,3) NULL,
    GramPerUnit decimal(18,3) NULL,
    TotalGram decimal(18,3) NULL,
    FishCount int NULL,
    FishAverageGram decimal(18,3) NULL,
    FishTotalGram decimal(18,3) NULL,
    FishBatchId bigint NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_GoodsReceiptLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_GoodsReceiptLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_GoodsReceiptLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_GoodsReceiptLine_Receipt FOREIGN KEY(GoodsReceiptId) REFERENCES dbo.RII_GoodsReceipt(Id),
    CONSTRAINT FK_RII_GoodsReceiptLine_Stock FOREIGN KEY(StockId) REFERENCES dbo.RII_STOCK(Id),
    CONSTRAINT FK_RII_GoodsReceiptLine_FishBatch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT CK_RII_GoodsReceiptLine_ItemType CHECK (ItemType IN (0,1)),
    CONSTRAINT CK_RII_GoodsReceiptLine_FeedShape CHECK (
        (ItemType = 0 AND QtyUnit IS NOT NULL AND GramPerUnit IS NOT NULL AND TotalGram IS NOT NULL AND FishCount IS NULL AND FishAverageGram IS NULL AND FishTotalGram IS NULL)
        OR
        (ItemType = 1 AND FishCount IS NOT NULL AND FishAverageGram IS NOT NULL AND FishTotalGram IS NOT NULL)
    )
);
GO

CREATE INDEX IX_RII_GoodsReceiptLine_GoodsReceiptId ON dbo.RII_GoodsReceiptLine(GoodsReceiptId);
CREATE INDEX IX_RII_GoodsReceiptLine_ItemType ON dbo.RII_GoodsReceiptLine(ItemType);
GO

CREATE TABLE dbo.RII_GoodsReceiptFishDistribution (
    Id bigint IDENTITY(1,1) NOT NULL,
    GoodsReceiptLineId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    FishBatchId bigint NOT NULL,
    FishCount int NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_GoodsReceiptFishDistribution_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_GoodsReceiptFishDistribution_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_GoodsReceiptFishDistribution PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_GoodsReceiptFishDistribution_Line FOREIGN KEY(GoodsReceiptLineId) REFERENCES dbo.RII_GoodsReceiptLine(Id),
    CONSTRAINT FK_RII_GoodsReceiptFishDistribution_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT FK_RII_GoodsReceiptFishDistribution_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT CK_RII_GoodsReceiptFishDistribution_Count CHECK (FishCount > 0)
);
GO

CREATE UNIQUE INDEX UX_RII_GoodsReceiptFishDistribution_LineCage_Active
ON dbo.RII_GoodsReceiptFishDistribution(GoodsReceiptLineId, ProjectCageId)
WHERE IsDeleted = 0;
GO

/* =========================================================
   FEEDING
   ========================================================= */
CREATE TABLE dbo.RII_Feeding (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    FeedingNo nvarchar(50) NOT NULL,
    FeedingDate datetime2(3) NOT NULL,
    FeedingDateOnly AS CAST(FeedingDate AS date) PERSISTED,
    FeedingSlot tinyint NOT NULL,
    SourceType tinyint NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_Feeding_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Feeding_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Feeding_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Feeding PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_Feeding_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_Feeding_Slot CHECK (FeedingSlot IN (0,1)),
    CONSTRAINT CK_RII_Feeding_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_Feeding_Project_Date_Slot_Active
ON dbo.RII_Feeding(ProjectId, FeedingDateOnly, FeedingSlot)
WHERE IsDeleted = 0;
GO

CREATE UNIQUE INDEX UX_RII_Feeding_FeedingNo_Active
ON dbo.RII_Feeding(FeedingNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_FeedingLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    FeedingId bigint NOT NULL,
    StockId bigint NOT NULL,
    QtyUnit decimal(18,3) NOT NULL,
    GramPerUnit decimal(18,3) NOT NULL,
    TotalGram decimal(18,3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_FeedingLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_FeedingLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_FeedingLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_FeedingLine_Feeding FOREIGN KEY(FeedingId) REFERENCES dbo.RII_Feeding(Id),
    CONSTRAINT FK_RII_FeedingLine_Stock FOREIGN KEY(StockId) REFERENCES dbo.RII_STOCK(Id),
    CONSTRAINT CK_RII_FeedingLine_Positive CHECK (QtyUnit > 0 AND GramPerUnit > 0 AND TotalGram > 0)
);
GO

CREATE TABLE dbo.RII_FeedingDistribution (
    Id bigint IDENTITY(1,1) NOT NULL,
    FeedingLineId bigint NOT NULL,
    FishBatchId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    FeedGram decimal(18,3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_FeedingDistribution_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_FeedingDistribution_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_FeedingDistribution PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_FeedingDistribution_Line FOREIGN KEY(FeedingLineId) REFERENCES dbo.RII_FeedingLine(Id),
    CONSTRAINT FK_RII_FeedingDistribution_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_FeedingDistribution_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_FeedingDistribution_FeedGram CHECK (FeedGram > 0)
);
GO

/* =========================================================
   MORTALITY
   ========================================================= */
CREATE TABLE dbo.RII_Mortality (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    MortalityDate date NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_Mortality_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Mortality_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Mortality_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Mortality PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_Mortality_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_Mortality_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_Mortality_ProjectDate_Active
ON dbo.RII_Mortality(ProjectId, MortalityDate)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_MortalityLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    MortalityId bigint NOT NULL,
    FishBatchId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    DeadCount int NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_MortalityLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_MortalityLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_MortalityLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_MortalityLine_Mortality FOREIGN KEY(MortalityId) REFERENCES dbo.RII_Mortality(Id),
    CONSTRAINT FK_RII_MortalityLine_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_MortalityLine_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_MortalityLine_DeadCount CHECK (DeadCount > 0)
);
GO

/* =========================================================
   TRANSFER
   ========================================================= */
CREATE TABLE dbo.RII_Transfer (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    TransferNo nvarchar(50) NOT NULL,
    TransferDate datetime2(3) NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_Transfer_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Transfer_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Transfer_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Transfer PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_Transfer_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_Transfer_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_Transfer_TransferNo_Active
ON dbo.RII_Transfer(TransferNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_TransferLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    TransferId bigint NOT NULL,
    FishBatchId bigint NOT NULL,
    FromProjectCageId bigint NOT NULL,
    ToProjectCageId bigint NOT NULL,
    FishCount int NOT NULL,
    AverageGram decimal(18,3) NOT NULL,
    BiomassGram decimal(18,3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_TransferLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_TransferLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_TransferLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_TransferLine_Transfer FOREIGN KEY(TransferId) REFERENCES dbo.RII_Transfer(Id),
    CONSTRAINT FK_RII_TransferLine_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_TransferLine_FromProjectCage FOREIGN KEY(FromProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT FK_RII_TransferLine_ToProjectCage FOREIGN KEY(ToProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_TransferLine_Positive CHECK (FishCount > 0 AND AverageGram > 0 AND BiomassGram > 0),
    CONSTRAINT CK_RII_TransferLine_FromToDiff CHECK (FromProjectCageId <> ToProjectCageId)
);
GO

/* =========================================================
   WEIGHING
   ========================================================= */
CREATE TABLE dbo.RII_Weighing (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    WeighingNo nvarchar(50) NOT NULL,
    WeighingDate datetime2(3) NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_Weighing_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_Weighing_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_Weighing_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_Weighing PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_Weighing_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_Weighing_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_Weighing_WeighingNo_Active
ON dbo.RII_Weighing(WeighingNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_WeighingLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    WeighingId bigint NOT NULL,
    FishBatchId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    MeasuredCount int NOT NULL,
    MeasuredAverageGram decimal(18,3) NOT NULL,
    MeasuredBiomassGram decimal(18,3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_WeighingLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_WeighingLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_WeighingLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_WeighingLine_Weighing FOREIGN KEY(WeighingId) REFERENCES dbo.RII_Weighing(Id),
    CONSTRAINT FK_RII_WeighingLine_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_WeighingLine_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_WeighingLine_Positive CHECK (MeasuredCount > 0 AND MeasuredAverageGram > 0 AND MeasuredBiomassGram > 0)
);
GO

/* =========================================================
   STOCK CONVERT
   ========================================================= */
CREATE TABLE dbo.RII_StockConvert (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    ConvertNo nvarchar(50) NOT NULL,
    ConvertDate datetime2(3) NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_StockConvert_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_StockConvert_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_StockConvert_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_StockConvert PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_StockConvert_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT CK_RII_StockConvert_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_StockConvert_ConvertNo_Active
ON dbo.RII_StockConvert(ConvertNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_StockConvertLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    StockConvertId bigint NOT NULL,
    FromFishBatchId bigint NOT NULL,
    ToFishBatchId bigint NOT NULL,
    FromProjectCageId bigint NOT NULL,
    ToProjectCageId bigint NOT NULL,
    FishCount int NOT NULL,
    AverageGram decimal(18,3) NOT NULL,
    BiomassGram decimal(18,3) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_StockConvertLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_StockConvertLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_StockConvertLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_StockConvertLine_Convert FOREIGN KEY(StockConvertId) REFERENCES dbo.RII_StockConvert(Id),
    CONSTRAINT FK_RII_StockConvertLine_FromBatch FOREIGN KEY(FromFishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_StockConvertLine_ToBatch FOREIGN KEY(ToFishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_StockConvertLine_FromProjectCage FOREIGN KEY(FromProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT FK_RII_StockConvertLine_ToProjectCage FOREIGN KEY(ToProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_StockConvertLine_Positive CHECK (FishCount > 0 AND AverageGram > 0 AND BiomassGram > 0)
);
GO

/* =========================================================
   BATCH LEDGER
   ========================================================= */
CREATE TABLE dbo.RII_BatchMovement (
    Id bigint IDENTITY(1,1) NOT NULL,
    FishBatchId bigint NOT NULL,
    ProjectCageId bigint NULL,
    MovementDate datetime2(3) NOT NULL,
    MovementType tinyint NOT NULL,
    SignedCount int NOT NULL,
    SignedBiomassGram decimal(18,3) NOT NULL,
    ReferenceTable nvarchar(50) NOT NULL,
    ReferenceId bigint NOT NULL,
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_BatchMovement_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_BatchMovement_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_BatchMovement PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_BatchMovement_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id),
    CONSTRAINT FK_RII_BatchMovement_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT CK_RII_BatchMovement_MovementType CHECK (MovementType IN (0,1,2,3,4,5))
);
GO

CREATE INDEX IX_RII_BatchMovement_BatchDate ON dbo.RII_BatchMovement(FishBatchId, MovementDate);
GO

/* =========================================================
   WEATHER
   ========================================================= */
CREATE TABLE dbo.RII_WeatherSeverity (
    Id bigint IDENTITY(1,1) NOT NULL,
    Code nvarchar(30) NOT NULL,
    Name nvarchar(100) NOT NULL,
    Score int NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_WeatherSeverity_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_WeatherSeverity_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_WeatherSeverity PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT CK_RII_WeatherSeverity_Score CHECK (Score >= 0)
);
GO

CREATE UNIQUE INDEX UX_RII_WeatherSeverity_Code_Active
ON dbo.RII_WeatherSeverity(Code)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_WeatherType (
    Id bigint IDENTITY(1,1) NOT NULL,
    Code nvarchar(30) NOT NULL,
    Name nvarchar(100) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_WeatherType_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_WeatherType_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_WeatherType PRIMARY KEY CLUSTERED (Id)
);
GO

CREATE UNIQUE INDEX UX_RII_WeatherType_Code_Active
ON dbo.RII_WeatherType(Code)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_DailyWeather (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    WeatherDate date NOT NULL,
    WeatherTypeId bigint NOT NULL,
    WeatherSeverityId bigint NOT NULL,
    TemperatureC decimal(18,3) NULL,
    WindKnot decimal(18,3) NULL,
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_DailyWeather_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_DailyWeather_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_DailyWeather PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_DailyWeather_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT FK_RII_DailyWeather_WeatherType FOREIGN KEY(WeatherTypeId) REFERENCES dbo.RII_WeatherType(Id),
    CONSTRAINT FK_RII_DailyWeather_WeatherSeverity FOREIGN KEY(WeatherSeverityId) REFERENCES dbo.RII_WeatherSeverity(Id)
);
GO

CREATE UNIQUE INDEX UX_RII_DailyWeather_ProjectDate_Active
ON dbo.RII_DailyWeather(ProjectId, WeatherDate)
WHERE IsDeleted = 0;
GO

/* =========================================================
   NET OPERATIONS
   ========================================================= */
CREATE TABLE dbo.RII_NetOperationType (
    Id bigint IDENTITY(1,1) NOT NULL,
    Code nvarchar(30) NOT NULL,
    Name nvarchar(100) NOT NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_NetOperationType_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_NetOperationType_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_NetOperationType PRIMARY KEY CLUSTERED (Id)
);
GO

CREATE UNIQUE INDEX UX_RII_NetOperationType_Code_Active
ON dbo.RII_NetOperationType(Code)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_NetOperation (
    Id bigint IDENTITY(1,1) NOT NULL,
    ProjectId bigint NOT NULL,
    OperationTypeId bigint NOT NULL,
    OperationNo nvarchar(50) NOT NULL,
    OperationDate datetime2(3) NOT NULL,
    Status tinyint NOT NULL CONSTRAINT DF_RII_NetOperation_Status DEFAULT (0),
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_NetOperation_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_NetOperation_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_NetOperation PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_NetOperation_Project FOREIGN KEY(ProjectId) REFERENCES dbo.RII_Project(Id),
    CONSTRAINT FK_RII_NetOperation_Type FOREIGN KEY(OperationTypeId) REFERENCES dbo.RII_NetOperationType(Id),
    CONSTRAINT CK_RII_NetOperation_Status CHECK (Status IN (0,1,2))
);
GO

CREATE UNIQUE INDEX UX_RII_NetOperation_OperationNo_Active
ON dbo.RII_NetOperation(OperationNo)
WHERE IsDeleted = 0;
GO

CREATE TABLE dbo.RII_NetOperationLine (
    Id bigint IDENTITY(1,1) NOT NULL,
    NetOperationId bigint NOT NULL,
    ProjectCageId bigint NOT NULL,
    FishBatchId bigint NULL,
    Note nvarchar(500) NULL,
    CreatedBy bigint NULL,
    CreatedDate datetime2(3) NOT NULL CONSTRAINT DF_RII_NetOperationLine_CreatedDate DEFAULT (sysutcdatetime()),
    UpdatedBy bigint NULL,
    UpdatedDate datetime2(3) NULL,
    IsDeleted bit NOT NULL CONSTRAINT DF_RII_NetOperationLine_IsDeleted DEFAULT (0),
    DeletedBy bigint NULL,
    DeletedDate datetime2(3) NULL,
    CONSTRAINT PK_RII_NetOperationLine PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_RII_NetOperationLine_Header FOREIGN KEY(NetOperationId) REFERENCES dbo.RII_NetOperation(Id),
    CONSTRAINT FK_RII_NetOperationLine_ProjectCage FOREIGN KEY(ProjectCageId) REFERENCES dbo.RII_ProjectCage(Id),
    CONSTRAINT FK_RII_NetOperationLine_Batch FOREIGN KEY(FishBatchId) REFERENCES dbo.RII_FishBatch(Id)
);
GO

/* =========================================================
   RULE ENFORCEMENT: Fish line requires GoodsReceipt.ProjectId
   =========================================================
Primary enforcement in application service (pre-post validation).
Optional DB hard guard trigger below.
*/
CREATE OR ALTER TRIGGER dbo.TR_RII_GoodsReceiptLine_RequireProjectForFish
ON dbo.RII_GoodsReceiptLine
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN dbo.RII_GoodsReceipt gr ON gr.Id = i.GoodsReceiptId
        WHERE i.IsDeleted = 0
          AND i.ItemType = 1
          AND gr.IsDeleted = 0
          AND gr.ProjectId IS NULL
    )
    BEGIN
        THROW 51001, 'Fish item lines require GoodsReceipt.ProjectId to be filled.', 1;
    END
END;
GO
