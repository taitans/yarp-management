using System;
using Volo.Abp.EventBus;

namespace Taitans.YarpManagement
{
    [EventName("YarpManagement.UpdateConfigurationEventData")]
    public class UpdateConfigurationEventData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime UpdateTime { get; set; }

        public UpdateConfigurationEventData(string name, string value, DateTime updateTime)
        {
            Name = name;
            Value = value;
            UpdateTime = updateTime;
        }
    }
}
