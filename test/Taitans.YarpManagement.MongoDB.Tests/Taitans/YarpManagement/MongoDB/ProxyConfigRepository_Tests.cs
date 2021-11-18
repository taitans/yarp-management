using Xunit;

namespace Taitans.YarpManagement.MongoDB
{
    [Collection(MongoTestCollection.Name)]
    public class ProxyConfigRepository_Tests : ProxyConfigRepository_Tests<YarpManagementMongoDbTestModule>
    {
    }
}
