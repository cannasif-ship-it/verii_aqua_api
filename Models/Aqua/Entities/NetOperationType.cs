using System;
using System.Collections.Generic;

namespace aqua_api.Models
{
    public class NetOperationType : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public ICollection<NetOperation> NetOperations { get; set; } = new List<NetOperation>();
    }
}
