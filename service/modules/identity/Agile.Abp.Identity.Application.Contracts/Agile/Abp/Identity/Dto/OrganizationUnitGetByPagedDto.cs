using Volo.Abp.Application.Dtos;

namespace Agile.Abp.Identity
{
    public class OrganizationUnitGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
