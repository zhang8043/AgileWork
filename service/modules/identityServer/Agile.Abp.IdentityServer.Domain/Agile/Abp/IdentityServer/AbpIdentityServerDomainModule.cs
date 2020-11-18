using Volo.Abp.Modularity;

namespace Agile.Abp.IdentityServer
{
    [DependsOn(typeof(Volo.Abp.IdentityServer.AbpIdentityServerDomainModule))]
    public class AbpIdentityServerDomainModule : AbpModule
    {
    }
}
