using BackendAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BackendAdmin
{
    public abstract class BackendAdminController : AbpController
    {
        protected BackendAdminController()
        {
            LocalizationResource = typeof(BackendAdminResource);
        }
    }
}
