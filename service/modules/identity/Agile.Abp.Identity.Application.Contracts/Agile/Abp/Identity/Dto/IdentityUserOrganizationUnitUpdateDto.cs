using System;
using System.ComponentModel.DataAnnotations;

namespace Agile.Abp.Identity
{
    public class IdentityUserOrganizationUnitUpdateDto
    {
        [Required]
        public Guid[] OrganizationUnitIds { get; set; }
    }
}
