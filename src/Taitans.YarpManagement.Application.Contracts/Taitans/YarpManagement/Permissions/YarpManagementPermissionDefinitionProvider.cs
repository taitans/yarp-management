using Taitans.YarpManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Taitans.YarpManagement.Permissions
{
    public class YarpManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        { 
            var yarpManagementGroup = context.AddGroup(YarpManagementPermissions.GroupName, L("Permission:YarpManagement"));

            var proxyConfigsPermission = yarpManagementGroup.AddPermission(YarpManagementPermissions.ProxyConfigs.Default, L("Permission:ProxyConfigs"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.Create, L("Permission:Create"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.Update, L("Permission:Edit"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.Delete, L("Permission:Delete"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.ViewChangeHistory, L("Permission:ViewChangeHistory"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.Reload, L("Permission:Reload"));
            proxyConfigsPermission.AddChild(YarpManagementPermissions.ProxyConfigs.RollBack, L("Permission:RollBack"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<YarpManagementResource>(name);
        }
    }
}