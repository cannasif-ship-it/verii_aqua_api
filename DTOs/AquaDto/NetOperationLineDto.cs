using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class NetOperationLineDto
    {
        public long Id { get; set; }
        public long NetOperationId { get; set; }
        public long ProjectCageId { get; set; }
        public long? FishBatchId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitGram { get; set; }
        public string? Note { get; set; }
    }

    public class CreateNetOperationLineDto
    {
        public long NetOperationId { get; set; }
        public long ProjectCageId { get; set; }
        public long? FishBatchId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? UnitGram { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateNetOperationLineDto : CreateNetOperationLineDto
    {
    }
}
