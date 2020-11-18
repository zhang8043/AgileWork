using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace Agile.Abp.SettingManagement
{
    [DependsOn(
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpSettingManagementApplicationContractsModule)
        )]
    public class AbpSettingManagementApplicationModule : AbpModule
    {
    }
}
