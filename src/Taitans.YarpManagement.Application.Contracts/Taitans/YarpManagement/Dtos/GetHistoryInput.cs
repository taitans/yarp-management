using Volo.Abp.Application.Dtos;

namespace Taitans.YarpManagement.Dtos
{
    public class GetHistoryInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}
