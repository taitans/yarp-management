using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace Taitans.YarpManagement
{
    public class ProxyConfig : FullAuditedAggregateRoot<Guid>
    {
        public ProxyConfig(Guid id, string name, string value, string version)
        {
            Id = id;
            Name = name;
            Value = value;
            Version = version;
        }

        public string Name { get; protected set; }
        public string Value { get; protected set; }
        public string Version { get; protected set; }

        public static string CreateCode(params long[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', ProxyConfigConsts.VersionLength))).JoinAsString(".");
        }

        public void RollBack()
        {
            IsDeleted = false;
        }
    }
}
