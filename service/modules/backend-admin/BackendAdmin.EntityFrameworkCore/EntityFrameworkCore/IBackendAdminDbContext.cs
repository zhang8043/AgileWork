using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BackendAdmin.EntityFrameworkCore
{
    [ConnectionStringName(BackendAdminDbProperties.ConnectionStringName)]
    public interface IBackendAdminDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}