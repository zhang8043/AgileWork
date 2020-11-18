using Agile.Abp.TenantManagement;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Agile.Abp.MultiTenancy.RemoteService
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpTenantManagementHttpApiClientModule))]
    public class AbpRemoteServiceMultiTenancyModule : AbpModule
    {
    }
}
