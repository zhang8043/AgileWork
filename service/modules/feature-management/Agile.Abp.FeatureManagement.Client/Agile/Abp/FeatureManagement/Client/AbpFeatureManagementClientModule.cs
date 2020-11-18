using Agile.Abp.FeatureManagement.Client;
using Agile.Abp.FeatureManagement.Client.Permissions;
using Agile.Abp.Features.Client;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;

namespace Agile.Abp.FeatureManagement
{
    [DependsOn(
        typeof(AbpFeaturesClientModule),
        typeof(AbpFeatureManagementDomainModule)
        )]
    public class AbpFeatureManagementClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<FeatureManagementOptions>(options =>
            {
                options.Providers.Add<ClientFeatureManagementProvider>();

                options.ProviderPolicies[ClientFeatureValueProvider.ProviderName] = ClientFeaturePermissionNames.Clients.ManageFeatures;
            });
        }
    }
}
