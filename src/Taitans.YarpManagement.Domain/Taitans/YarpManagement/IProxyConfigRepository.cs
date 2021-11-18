using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Taitans.YarpManagement
{
    public interface IProxyConfigRepository : IRepository<ProxyConfig, Guid>
    {
        Task<long> GetCountAsync(
            string filter = null,
            string name = null, 
            string version = null,
            CancellationToken cancellationToken = default);
        Task<List<ProxyConfig>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            string name = null, 
            string version = null,  
            CancellationToken cancellationToken = default);
        Task<long> GetCountByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<List<ProxyConfig>> GetListByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
