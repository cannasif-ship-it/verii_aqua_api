using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class GoodsReceiptLineDto
    {
        public long Id { get; set; }
        public long GoodsReceiptId { get; set; }
        public GoodsReceiptItemType ItemType { get; set; }
        public long StockId { get; set; }
        public decimal? QtyUnit { get; set; }
        public decimal? GramPerUnit { get; set; }
        public decimal? TotalGram { get; set; }
        public int? FishCount { get; set; }
        public decimal? FishAverageGram { get; set; }
        public decimal? FishTotalGram { get; set; }
        public long? FishBatchId { get; set; }
        public Stock? Stock { get; set; }
    }

    public class CreateGoodsReceiptLineDto
    {
        public long GoodsReceiptId { get; set; }
        public GoodsReceiptItemType ItemType { get; set; }
        public long StockId { get; set; }
        public decimal? QtyUnit { get; set; }
        public decimal? GramPerUnit { get; set; }
        public decimal? TotalGram { get; set; }
        public int? FishCount { get; set; }
        public decimal? FishAverageGram { get; set; }
        public decimal? FishTotalGram { get; set; }
        public long? FishBatchId { get; set; }
        public Stock? Stock { get; set; }
    }

    public class UpdateGoodsReceiptLineDto : CreateGoodsReceiptLineDto
    {
    }
}
