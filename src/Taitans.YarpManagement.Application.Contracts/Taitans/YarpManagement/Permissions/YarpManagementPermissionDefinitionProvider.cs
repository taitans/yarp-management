using Taitans.YarpManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Taitans.YarpManagement.Permissions
{
    public class YarpManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(YarpManagementPermissions.GroupName, L("Permission:YarpManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<YarpManagementResource>(name);
        }
    }
}