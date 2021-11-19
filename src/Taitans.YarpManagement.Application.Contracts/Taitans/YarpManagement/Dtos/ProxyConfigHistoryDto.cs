using System;
using Volo.Abp.Application.Dtos;

namespace Taitans.YarpManagement.Dtos
{
    public class ProxyConfigHistoryDto : EntityDto<Guid>
    {
        public string Version { get; set; }
        public string Value { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsCurrent { get; set; }
    }
}
