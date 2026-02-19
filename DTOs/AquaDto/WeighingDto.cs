using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class WeighingDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string WeighingNo { get; set; }
        public DateTime WeighingDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateWeighingDto
    {
        public long ProjectId { get; set; }
        public string WeighingNo { get; set; }
        public DateTime WeighingDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateWeighingDto : CreateWeighingDto
    {
    }
}
