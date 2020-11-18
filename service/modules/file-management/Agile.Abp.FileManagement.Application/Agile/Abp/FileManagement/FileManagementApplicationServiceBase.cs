using Agile.Abp.FileManagement.Localization;
using Volo.Abp.Application.Services;

namespace Agile.Abp.FileManagement
{
    public class FileManagementApplicationServiceBase : ApplicationService
    {
        protected FileManagementApplicationServiceBase()
        {
            LocalizationResource = typeof(AbpFileManagementResource);
        }
    }
}
