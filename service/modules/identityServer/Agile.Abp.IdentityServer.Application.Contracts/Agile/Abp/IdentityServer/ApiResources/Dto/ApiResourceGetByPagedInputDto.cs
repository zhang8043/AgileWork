using Volo.Abp.Application.Dtos;

namespace Agile.Abp.IdentityServer.ApiResources
{
    public class ApiResourceGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
