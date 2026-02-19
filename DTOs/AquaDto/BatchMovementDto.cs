using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class BatchMovementDto
    {
        public long Id { get; set; }
        public long FishBatchId { get; set; }
        public long? ProjectCageId { get; set; }
        public DateTime MovementDate { get; set; }
        public BatchMovementType MovementType { get; set; }
        public int SignedCount { get; set; }
        public decimal SignedBiomassGram { get; set; }
        public string ReferenceTable { get; set; }
        public long ReferenceId { get; set; }
        public string? Note { get; set; }
    }

    public class CreateBatchMovementDto
    {
        public long FishBatchId { get; set; }
        public long? ProjectCageId { get; set; }
        public DateTime MovementDate { get; set; }
        public BatchMovementType MovementType { get; set; }
        public int SignedCount { get; set; }
        public decimal SignedBiomassGram { get; set; }
        public string ReferenceTable { get; set; }
        public long ReferenceId { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateBatchMovementDto : CreateBatchMovementDto
    {
    }
}
