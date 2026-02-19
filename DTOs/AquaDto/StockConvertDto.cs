using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class StockConvertDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public string ConvertNo { get; set; }
        public DateTime ConvertDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class CreateStockConvertDto
    {
        public long ProjectId { get; set; }
        public string ConvertNo { get; set; }
        public DateTime ConvertDate { get; set; }
        public DocumentStatus Status { get; set; }
        public string? Note { get; set; }
    }

    public class UpdateStockConvertDto : CreateStockConvertDto
    {
    }
}
