using Volo.Abp.Application.Dtos;

namespace Agile.Abp.IdentityServer.Grants
{
    public class PersistedGrantGetPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string SubjectId { get; set; }
    }
}
