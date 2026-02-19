using System;
using System.Collections.Generic;

namespace aqua_api.Models
{
    public class Cage : BaseEntity
    {
        public string CageCode { get; set; } = string.Empty;
        public string CageName { get; set; } = string.Empty;
        public int? CapacityCount { get; set; }
        public decimal? CapacityGram { get; set; }

        public ICollection<ProjectCage> ProjectCages { get; set; } = new List<ProjectCage>();
    }
}
