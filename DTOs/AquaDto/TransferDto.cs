using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class TransferDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public string TransferNo { get; set; }
        public DateTime TransferDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateTransferDto
    {
        public long ProjectId { get; set; }
        public string TransferNo { get; set; }
        public DateTime TransferDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateTransferDto : CreateTransferDto
    {
    }
}
