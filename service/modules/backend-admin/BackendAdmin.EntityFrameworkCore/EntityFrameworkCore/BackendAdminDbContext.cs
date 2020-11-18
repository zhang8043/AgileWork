using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BackendAdmin.EntityFrameworkCore
{
    [ConnectionStringName(BackendAdminDbProperties.ConnectionStringName)]
    public class BackendAdminDbContext : AbpDbContext<BackendAdminDbContext>, IBackendAdminDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public BackendAdminDbContext(DbContextOptions<BackendAdminDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBackendAdmin();
        }
    }
}