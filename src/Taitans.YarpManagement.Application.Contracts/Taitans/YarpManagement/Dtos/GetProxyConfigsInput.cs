using Volo.Abp.Application.Dtos;

namespace Taitans.YarpManagement.Dtos
{
    public class GetProxyConfigsInput: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
