using Volo.Abp.Application.Dtos;

namespace Agile.Abp.IdentityServer.Clients
{
    public class ClientGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
