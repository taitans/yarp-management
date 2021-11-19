using System;
using Volo.Abp.Application.Dtos;

namespace Taitans.YarpManagement.Dtos
{
    public class ProxyConfigDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Version { get; set; }
    }
}
