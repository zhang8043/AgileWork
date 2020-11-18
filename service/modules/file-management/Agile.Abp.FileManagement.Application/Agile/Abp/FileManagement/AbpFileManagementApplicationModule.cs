using Volo.Abp.Modularity;

namespace Agile.Abp.FileManagement
{
    [DependsOn(
        typeof(AbpFileManagementDomainModule),
        typeof(AbpFileManagementApplicationContractsModule))]
    public class AbpFileManagementApplicationModule : AbpModule
    {

    }
}
