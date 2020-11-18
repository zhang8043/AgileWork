using Volo.Abp.ObjectExtending;

namespace Agile.Abp.Identity
{
    public class OrganizationUnitUpdateDto : ExtensibleObject
    {
        public string DisplayName { get; set; }
    }
}
