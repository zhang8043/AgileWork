using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BackendAdmin.EntityFrameworkCore
{
    public class BackendAdminHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BackendAdminHostMigrationsDbContext>
    {
        public BackendAdminHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BackendAdminHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new BackendAdminHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
