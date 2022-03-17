using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Taitans.YarpManagement.Dtos
{
    public class ProxyConfigDto : ExtensibleEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Version { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
