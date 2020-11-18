using Volo.Abp.Modularity;

namespace Agile.Abp.Account
{
    [DependsOn(typeof(AbpAccountDomainSharedModule))]
    public class AbpAccountApplicationContractsModule : AbpModule
    {
    }
}
