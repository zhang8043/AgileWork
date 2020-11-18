using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BackendAdmin.EntityFrameworkCore
{
    public class BackendAdminModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public BackendAdminModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}