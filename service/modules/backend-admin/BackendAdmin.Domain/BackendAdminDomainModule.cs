using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace BackendAdmin
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(BackendAdminDomainSharedModule)
    )]
    public class BackendAdminDomainModule : AbpModule
    {

    }
}
