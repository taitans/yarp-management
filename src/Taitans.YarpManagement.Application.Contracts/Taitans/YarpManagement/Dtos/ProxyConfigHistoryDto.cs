using System;

namespace Taitans.YarpManagement.Dtos
{
    public class ProxyConfigHistoryDto
    {
        public string Version { get; set; }
        public string Value { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsCurrent { get; set; }
    }
}
