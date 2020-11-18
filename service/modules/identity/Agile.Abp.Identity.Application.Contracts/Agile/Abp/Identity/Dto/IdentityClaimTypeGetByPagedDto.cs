using Volo.Abp.Application.Dtos;

namespace Agile.Abp.Identity
{
    public class IdentityClaimTypeGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
