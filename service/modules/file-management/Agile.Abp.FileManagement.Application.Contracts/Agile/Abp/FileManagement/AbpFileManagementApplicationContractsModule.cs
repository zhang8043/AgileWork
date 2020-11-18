using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Agile.Abp.FileManagement
{
    [DependsOn(
        typeof(AbpFileManagementDomainSharedModule),
        typeof(AbpDddApplicationModule))]
    public class AbpFileManagementApplicationContractsModule : AbpModule
    {
    }
}
