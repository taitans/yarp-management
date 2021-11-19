using Volo.Abp.Reflection;

namespace Taitans.YarpManagement.Permissions
{
    public class YarpManagementPermissions
    {
        public const string GroupName = "YarpManagement";

        public static class ProxyConfigs
        {
            public const string Default = GroupName + ".ProxyConfigs";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ViewChangeHistory = Default + ".ViewChangeHistory";
            public const string RollBack = Default + ".RollBack";
            public const string Reload = Default + ".Reload";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(YarpManagementPermissions));
        }
    }
}