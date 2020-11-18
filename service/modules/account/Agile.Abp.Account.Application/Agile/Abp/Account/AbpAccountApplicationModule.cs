using Volo.Abp.Modularity;

namespace Agile.Abp.Account
{
    [DependsOn(
        typeof(AbpAccountDomainModule), 
        typeof(Volo.Abp.Account.AbpAccountApplicationModule),
        typeof(AbpAccountApplicationContractsModule))]
    public class AbpAccountApplicationModule : AbpModule
    {

    }
}
