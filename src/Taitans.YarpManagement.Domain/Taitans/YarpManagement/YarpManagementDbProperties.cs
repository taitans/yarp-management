namespace Taitans.YarpManagement
{
    public static class YarpManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Ym";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "YarpManagement";
    }
}
