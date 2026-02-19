using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class MortalityDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public DateTime MortalityDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateMortalityDto
    {
        public long ProjectId { get; set; }
        public DateTime MortalityDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateMortalityDto : CreateMortalityDto
    {
    }
}
