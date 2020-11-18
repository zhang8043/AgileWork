using BackendAdmin.Localization;
using Volo.Abp.Application.Services;

namespace BackendAdmin
{
    public abstract class BackendAdminAppService : ApplicationService
    {
        protected BackendAdminAppService()
        {
            LocalizationResource = typeof(BackendAdminResource);
            ObjectMapperContext = typeof(BackendAdminApplicationModule);
        }
    }
}
