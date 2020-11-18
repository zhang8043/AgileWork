using Volo.Abp.Modularity;

namespace Agile.Abp.PermissionManagement
{
    [DependsOn(
        typeof(Volo.Abp.PermissionManagement.AbpPermissionManagementDomainModule))]
    public class AbpPermissionManagementDomainModule : AbpModule
    {

    }
}
