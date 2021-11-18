using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    public class MongoProxyConfigRepository : MongoDbRepository<IYarpManagementMongoDbContext, ProxyConfig, Guid>, IProxyConfigRepository
    {
        public MongoProxyConfigRepository(IMongoDbContextProvider<IYarpManagementMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(string filter = null, string name = null, string version = null, CancellationToken cancellationToken = default)
        {
            return await (await GetMongoQueryableAsync(cancellationToken))
                 .WhereIf(!string.IsNullOrWhiteSpace(filter),
                     x => x.Name.Contains(filter) ||
                          x.Version.Contains(filter) ||
                          x.Value.Contains(filter))
                 .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                 .WhereIf(!string.IsNullOrWhiteSpace(version), x => x.Version == version)
                 .As<IMongoQueryable<ProxyConfig>>()
                 .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await (await GetMongoQueryableAsync(cancellationToken))
                .Where(x => x.Name == name)
                .As<IMongoQueryable<ProxyConfig>>()
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProxyConfig>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            string name = null,
            string version = null,
            CancellationToken cancellationToken = default)
        {
            return await (await GetMongoQueryableAsync(cancellationToken))
                .WhereIf(!string.IsNullOrWhiteSpace(filter),
                     x => x.Name.Contains(filter) ||
                          x.Version.Contains(filter) ||
                          x.Value.Contains(filter))
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .WhereIf(!string.IsNullOrWhiteSpace(version), x => x.Version == version)
                .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(ProxyConfig.Name) : sorting)
                .As<IMongoQueryable<ProxyConfig>>()
                .PageBy<ProxyConfig, IMongoQueryable<ProxyConfig>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<ProxyConfig>> GetListByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await (await GetMongoQueryableAsync(cancellationToken))
                .Where(x => x.Name == name)
                .As<IMongoQueryable<ProxyConfig>>()
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
