using System;
using System.Collections.Generic;

namespace aqua_api.Models
{
    public class BatchMovement : BaseEntity
    {
        public long FishBatchId { get; set; }
        public long? ProjectCageId { get; set; }
        public DateTime MovementDate { get; set; }
        public BatchMovementType MovementType { get; set; }
        public int SignedCount { get; set; }
        public decimal SignedBiomassGram { get; set; }
        public string ReferenceTable { get; set; } = string.Empty;
        public long ReferenceId { get; set; }
        public string? Note { get; set; }

        public FishBatch? FishBatch { get; set; }
        public ProjectCage? ProjectCage { get; set; }
    }
}
