using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class FishBatchDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string BatchCode { get; set; }
        public long FishStockId { get; set; }
        public decimal CurrentAverageGram { get; set; }
        public DateTime StartDate { get; set; }
        public long? SourceGoodsReceiptLineId { get; set; }
        public Stock? FishStock { get; set; }
    }

    public class CreateFishBatchDto
    {
        public long ProjectId { get; set; }
        public string BatchCode { get; set; }
        public long FishStockId { get; set; }
        public decimal CurrentAverageGram { get; set; }
        public DateTime StartDate { get; set; }
        public long? SourceGoodsReceiptLineId { get; set; }
        public Stock? FishStock { get; set; }
    }

    public class UpdateFishBatchDto : CreateFishBatchDto
    {
    }
}
