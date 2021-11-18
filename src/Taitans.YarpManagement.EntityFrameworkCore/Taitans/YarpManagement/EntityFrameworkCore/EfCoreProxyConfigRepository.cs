using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    public class EfCoreProxyConfigRepository : EfCoreRepository<IYarpManagementDbContext, ProxyConfig, Guid>, IProxyConfigRepository, ITransientDependency
    {
        public EfCoreProxyConfigRepository(IDbContextProvider<IYarpManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<long> GetCountAsync(
            string filter = null,
            string name = null,
            string version = null,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
               .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter) ||
                         u.Value.Contains(filter) ||
                         u.Version.Contains(filter)
               )
               .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
               .WhereIf(!string.IsNullOrWhiteSpace(version), x => x.Version == version)
               .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var count = await (await GetDbSetAsync())
                .Where(x => x.Name == name)
                .LongCountAsync(GetCancellationToken(cancellationToken));

            return count;
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
            return await (await GetDbSetAsync())
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter) ||
                         u.Value.Contains(filter) ||
                         u.Version.Contains(filter))
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .WhereIf(!string.IsNullOrWhiteSpace(version), x => x.Version == version)
                .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(ProxyConfig.Name) : sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<ProxyConfig>> GetListByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .Where(x => x.Name == name)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
