using System;

namespace Taitans.YarpManagement
{
    public static class YarpManagementTestData
    {
        public static Guid RollBackId { get; set; } = Guid.NewGuid();
        public static Guid CurrentId { get; set; } = Guid.NewGuid();
        public static string Name { get; set; } = "Loongle";
        public static string CurrentValue { get; set; } = "Good";
        public static string RollBackValue { get; set; } = "Oh Yeah!";
    }
}
