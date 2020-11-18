using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement.Localization;

namespace Agile.Abp.TenantManagement
{
    public abstract class TenantManagementAppServiceBase : ApplicationService
    {
        protected TenantManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpTenantManagementApplicationModule);
            LocalizationResource = typeof(AbpTenantManagementResource);
        }
    }
}
