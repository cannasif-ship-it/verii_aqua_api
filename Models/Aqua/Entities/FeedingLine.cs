using System;
using System.Collections.Generic;

namespace aqua_api.Models
{
    public class FeedingLine : BaseEntity
    {
        public long FeedingId { get; set; }
        public long StockId { get; set; }
        public decimal QtyUnit { get; set; }
        public decimal GramPerUnit { get; set; }
        public decimal TotalGram { get; set; }

        public Feeding? Feeding { get; set; }
        public Stock? Stock { get; set; }
        public ICollection<FeedingDistribution> Distributions { get; set; } = new List<FeedingDistribution>();
    }
}
