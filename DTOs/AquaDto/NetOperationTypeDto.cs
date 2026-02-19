using System;
using aqua_api.Models;

namespace aqua_api.DTOs
{
    public class NetOperationTypeDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CreateNetOperationTypeDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class UpdateNetOperationTypeDto : CreateNetOperationTypeDto
    {
    }
}
