using System;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Agile.Shared;
using BackendAdmin.EntityFrameworkCore;
using Agile.Abp.FileManagement;
using Agile.Abp.SettingManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.FeatureManagement;
using Agile.Abp.Auditing;
using Agile.Abp.TenantManagement;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Agile.Abp.MultiTenancy.DbFinder;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Localization;
using Agile.Abp.Account;
using Agile.Abp.BackendAdmin.MultiTenancy;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Auditing;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EventBus.RabbitMq;

namespace BackendAdmin
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEventBusRabbitMqModule),
        typeof(BackendAdminApplicationModule),
        typeof(BackendAdminEntityFrameworkCoreModule),
        typeof(BackendAdminHttpApiModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(Agile.Abp.Identity.AbpIdentityHttpApiModule),
        typeof(Agile.Abp.Identity.AbpIdentityApplicationModule),
        typeof(Agile.Abp.Identity.AbpIdentityApplicationContractsModule),
        typeof(Agile.Abp.Identity.EntityFrameworkCore.AbpIdentityEntityFrameworkCoreModule),
        typeof(Agile.Abp.Account.AbpAccountApplicationModule),
        typeof(Agile.Abp.Account.AbpAccountHttpApiModule),
        typeof(Agile.Abp.Account.AbpAccountApplicationContractsModule),
        typeof(Agile.Abp.IdentityServer.AbpIdentityServerApplicationModule),
        typeof(Agile.Abp.IdentityServer.AbpIdentityServerHttpApiModule),
        typeof(Agile.Abp.IdentityServer.AbpIdentityServerApplicationContractsModule),
        typeof(Agile.Abp.IdentityServer.EntityFrameworkCore.AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(AbpFileManagementApplicationContractsModule),
        typeof(AbpAuditingApplicationModule),
        typeof(AbpAuditingHttpApiModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpSettingManagementApplicationModule),
        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpDbFinderMultiTenancyModule),
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(AbpAspNetCoreSerilogModule)
        )]
    public class BackendAdminHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "Agile.Abp.Application";
                options.GlobalCacheEntryOptions.SlidingExpiration = TimeSpan.FromDays(30);
                options.GlobalCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendAdmin API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<PermissionManagementOptions>(options =>
            {
                options.ProviderPolicies[ClientPermissionValueProvider.ProviderName] =
                    Agile.Abp.IdentityServer.AbpIdentityServerPermissions.Clients.ManagePermissions;
            });

            Configure<AbpTenantResolveOptions>(options =>
            {
                options.TenantResolvers.Insert(0, new AuthorizationTenantResolveContributor());
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.AddNamespace("Volo.Abp.TenantManagement");
                options.AutoEventSelectors.AddNamespace("Volo.Abp.Identity");
                options.AutoEventSelectors.AddNamespace("Volo.Abp.IdentityServer");
            });

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.ApplicationName = "BackendAdmin";
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));

                options.Resources
                      .Get<IdentityResource>()
                      .AddVirtualJson("/Localization");
                options
                    .AddLanguagesMapOrUpdate(
                        "vue-admin",
                        new NameValue("zh-Hans", "zh"),
                        new NameValue("en", "en"));

                options
                    .AddLanguageFilesMapOrUpdate(
                        "vue-admin",
                        new NameValue("zh-Hans", "zh"),
                        new NameValue("en", "en"));
            });

            //Updates AbpClaimTypes to be compatible with identity server claims.
            AbpClaimTypes.UserId = JwtClaimTypes.Subject;
            AbpClaimTypes.UserName = JwtClaimTypes.Name;
            AbpClaimTypes.Role = JwtClaimTypes.Role;
            AbpClaimTypes.Email = JwtClaimTypes.Email;

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BackendAdminHostModule>("BackendAdmin");
            });

            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.ApiName = configuration["AuthServer:ApiName"];
                });

            if (!hostingEnvironment.IsDevelopment())
            {
                var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                context.Services
                    .AddDataProtection()
                    .PersistKeysToStackExchangeRedis(redis, "BackendAdmin-Protection-Keys");
            }

            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
                app.UseHsts();
            }

            // http调用链
            app.UseCorrelationId();
            // 虚拟文件系统
            app.UseVirtualFiles();
            // 本地化
            app.UseAbpRequestLocalization();
            //路由
            app.UseRouting();
            // 认证
            app.UseAuthentication();
            app.UseAbpClaimsMap();
            // jwt
            app.UseJwtTokenMiddleware();
            // 多租户
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }
            // Swagger
            app.UseSwagger();
            // Swagger可视化界面
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });
            // 审计日志
            app.UseAuditing();
            // 路由
            app.UseConfiguredEndpoints();

            app.UseHttpsRedirection();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthorization();
            app.UseAbpSerilogEnrichers();
        }
    }
}
