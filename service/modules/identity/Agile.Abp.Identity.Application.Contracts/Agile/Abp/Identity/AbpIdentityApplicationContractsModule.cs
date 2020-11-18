using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Agile.Abp.Identity
{
    [DependsOn(
        typeof(Volo.Abp.Identity.AbpIdentityApplicationContractsModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpDddApplicationModule)
        )]
    public class AbpIdentityApplicationContractsModule : AbpModule
    {
    }
}
