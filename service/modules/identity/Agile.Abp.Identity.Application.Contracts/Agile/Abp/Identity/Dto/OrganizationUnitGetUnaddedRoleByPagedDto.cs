using Volo.Abp.Application.Dtos;

namespace Agile.Abp.Identity
{
    public class OrganizationUnitGetUnaddedRoleByPagedDto : PagedAndSortedResultRequestDto
    {

        public string Filter { get; set; }
    }
}
