using Taitans.YarpManagementDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Taitans.YarpManagementDemo.Permissions;

public class YarpManagementDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(YarpManagementDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(YarpManagementDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<YarpManagementDemoResource>(name);
    }
}
