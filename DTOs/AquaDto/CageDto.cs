using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class CageDto
    {
        public long Id { get; set; }
        public string CageCode { get; set; }
        public string CageName { get; set; }
        public int? CapacityCount { get; set; }
        public decimal? CapacityGram { get; set; }
    }

    public class CreateCageDto
    {
        public string CageCode { get; set; }
        public string CageName { get; set; }
        public int? CapacityCount { get; set; }
        public decimal? CapacityGram { get; set; }
    }

    public class UpdateCageDto : CreateCageDto
    {
    }
}
