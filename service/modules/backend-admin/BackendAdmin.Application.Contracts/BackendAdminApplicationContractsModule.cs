using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace BackendAdmin
{
    [DependsOn(
        typeof(BackendAdminDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class BackendAdminApplicationContractsModule : AbpModule
    {

    }
}
