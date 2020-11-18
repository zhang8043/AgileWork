using Localization.Resources.AbpUi;
using BackendAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace BackendAdmin
{
    [DependsOn(
        typeof(BackendAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class BackendAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(BackendAdminHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BackendAdminResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
