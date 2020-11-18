using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Agile.Abp.FileManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpMultiTenancyModule),
        typeof(AbpFileManagementDomainSharedModule)
        )]
    public class AbpFileManagementDomainModule : AbpModule
    {
    }
}
