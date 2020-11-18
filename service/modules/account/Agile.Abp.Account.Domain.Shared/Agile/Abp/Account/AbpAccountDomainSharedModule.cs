using Agile.Abp.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Agile.Abp.Account
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class AbpAccountDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAccountDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AccountResource>("zh-Hans")
                    .AddVirtualJson("/Agile/Abp/Account/Localization/Resources");
            });
        }
    }
}
