using System;
using Volo.Abp.Application.Dtos;

namespace Agile.Abp.TenantManagement
{
    public class TenantDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}