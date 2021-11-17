using Volo.Abp.Reflection;

namespace Taitans.YarpManagement.Permissions
{
    public class YarpManagementPermissions
    {
        public const string GroupName = "YarpManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(YarpManagementPermissions));
        }
    }
}