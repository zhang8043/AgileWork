using System.ComponentModel.DataAnnotations;
using Volo.Abp.IdentityServer.ApiResources;

namespace Agile.Abp.IdentityServer.ApiResources
{
    public class ApiResourceCreateDto : ApiResourceCreateOrUpdateDto
    {
        [Required]
        [StringLength(ApiResourceConsts.NameMaxLength)]
        public string Name { get; set; }
    }
}
