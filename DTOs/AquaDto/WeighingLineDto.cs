using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class WeighingLineDto
    {
        public long Id { get; set; }
        public long WeighingId { get; set; }
        public long FishBatchId { get; set; }
        public long ProjectCageId { get; set; }
        public int MeasuredCount { get; set; }
        public decimal MeasuredAverageGram { get; set; }
        public decimal MeasuredBiomassGram { get; set; }
    }

    public class CreateWeighingLineDto
    {
        public long WeighingId { get; set; }
        public long FishBatchId { get; set; }
        public long ProjectCageId { get; set; }
        public int MeasuredCount { get; set; }
        public decimal MeasuredAverageGram { get; set; }
        public decimal MeasuredBiomassGram { get; set; }
    }

    public class UpdateWeighingLineDto : CreateWeighingLineDto
    {
    }
}
