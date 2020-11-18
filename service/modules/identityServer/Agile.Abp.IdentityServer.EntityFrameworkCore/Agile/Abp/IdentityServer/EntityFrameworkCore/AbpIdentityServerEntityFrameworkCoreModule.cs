using Volo.Abp.Modularity;

namespace Agile.Abp.IdentityServer.EntityFrameworkCore
{
    [DependsOn(typeof(Agile.Abp.IdentityServer.AbpIdentityServerDomainModule))]
    [DependsOn(typeof(Volo.Abp.IdentityServer.EntityFrameworkCore.AbpIdentityServerEntityFrameworkCoreModule))]
    public class AbpIdentityServerEntityFrameworkCoreModule : AbpModule
    {
    }
}
