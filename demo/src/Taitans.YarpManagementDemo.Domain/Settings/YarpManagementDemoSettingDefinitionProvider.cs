using Volo.Abp.Settings;

namespace Taitans.YarpManagementDemo.Settings;

public class YarpManagementDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(YarpManagementDemoSettings.MySetting1));
    }
}
