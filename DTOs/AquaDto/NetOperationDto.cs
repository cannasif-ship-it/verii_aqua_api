using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class NetOperationDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long OperationTypeId { get; set; }
        public string OperationNo { get; set; }
        public DateTime OperationDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateNetOperationDto
    {
        public long ProjectId { get; set; }
        public long OperationTypeId { get; set; }
        public string OperationNo { get; set; }
        public DateTime OperationDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateNetOperationDto : CreateNetOperationDto
    {
    }
}
