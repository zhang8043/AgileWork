using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Agile.Abp.MultiTenancy.DbFinder
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpTenantManagementDomainModule)
        )]
    public class AbpDbFinderMultiTenancyModule : AbpModule
    {
    }
}
