using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Agile.Abp.Identity
{
    public class IdentityUserClaimUpdateDto : IdentityUserClaimCreateDto
    {
        [Required]
        [DynamicMaxLength(typeof(IdentityUserClaimConsts), nameof(IdentityUserClaimConsts.MaxClaimValueLength))]
        public string NewClaimValue { get; set; }
    }
}
