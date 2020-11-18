using Volo.Abp.Application.Dtos;

namespace Agile.Abp.TenantManagement
{
    public class TenantGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}