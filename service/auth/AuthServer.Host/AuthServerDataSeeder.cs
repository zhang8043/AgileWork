using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

using Agile.Abp.IdentityServer;

namespace AuthServer.Host
{
    public class AuthServerDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IConfiguration _configuration;

        public AuthServerDataSeeder(
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            IPermissionDataSeeder permissionDataSeeder)
        {
            _clientRepository = clientRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceDataSeeder = identityResourceDataSeeder;
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            _configuration = configuration;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiResourcesAsync();
            await CreateClientsAsync();
        }

        private async Task CreateApiResourcesAsync()
        {
            var commonApiUserClaims = new[]
            {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };

            await CreateApiResourceAsync("AuthServer", commonApiUserClaims);
            await CreateApiResourceAsync("BackendAdmin", commonApiUserClaims);
            await CreateApiResourceAsync("InternalGateway", commonApiUserClaims);
            await CreateApiResourceAsync("BackendAdminAppGateway", commonApiUserClaims);
        }

        private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
        {
            var apiResource = await _apiResourceRepository.FindByNameAsync(name);
            if (apiResource == null)
            {
                apiResource = await _apiResourceRepository.InsertAsync(
                    new ApiResource(
                        _guidGenerator.Create(),
                        name,
                        name + " API"
                    ),
                    autoSave: true
                );
            }

            foreach (var claim in claims)
            {
                if (apiResource.FindClaim(claim) == null)
                {
                    apiResource.AddUserClaim(claim);
                }
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
            const string commonSecret = "E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=";

            var commonScopes = new[]
            {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address"
            };

            var configurationSection = _configuration.GetSection("IdentityServer:Clients");

            //Web Client
            var webClientId = configurationSection["AuthManagement:ClientId"];
            if (!webClientId.IsNullOrWhiteSpace())
            {
                var webClientRootUrl = configurationSection["AuthManagement:RootUrl"].EnsureEndsWith('/');
                await CreateClientAsync(
                    webClientId,
                    commonScopes.Union(new[] { "AuthServer", "BackendAdminAppGateway", "InternalGateway", "BackendAdmin" }),
                    new[] { "hybrid" },
                    commonSecret,
                    redirectUri: $"{webClientRootUrl}signin-oidc",
                    postLogoutRedirectUri: $"{webClientRootUrl}signout-callback-oidc",
                    corsOrigins: configurationSection["CorsOrigins"]
                );
            }

            //Console Test Client
            var consoleClientId = configurationSection["AuthBackendAdmin:ClientId"];
            if (!consoleClientId.IsNullOrWhiteSpace())
            {
                await CreateClientAsync(
                    consoleClientId,
                    commonScopes.Union(new[] { "AuthServer", "BackendAdminAppGateway", "InternalGateway", "BackendAdmin" }),
                    new[] { "password", "client_credentials" },
                    commonSecret
                );
            }

            //ApiGateway
            var apigatewayClientId = configurationSection["AuthApiGateway:ClientId"];
            if (!apigatewayClientId.IsNullOrWhiteSpace())
            {
                await CreateClientAsync(
                    apigatewayClientId,
                    commonScopes.Union(new[] { "AuthServer", "BackendAdminAppGateway", "InternalGateway", "BackendAdmin" }),
                    new[] { "client_credentials" },
                    commonSecret,
                    permissions: new[] {
                    "ApiGateway.Global",
                    "ApiGateway.Global.Export",
                    "ApiGateway.Route",
                    "ApiGateway.Route.Export",
                    "ApiGateway.DynamicRoute",
                    "ApiGateway.DynamicRoute.Export",
                    "ApiGateway.AggregateRoute",
                    "ApiGateway.AggregateRoute.Export",
                    AbpIdentityServerPermissions.ApiResources.Default,
                    IdentityPermissions.UserLookup.Default,
                    IdentityPermissions.Users.Default,
                    TenantManagementPermissions.Tenants.Default}
                );
            }

            await CreateClientAsync(
                "console-client-demo",
                new[] { "AuthServer", "BackendAdminAppGateway", "InternalGateway", "BackendAdmin" },
                new[] { "client_credentials", "password" },
                commonSecret,
                permissions: new[] {
                    "ApiGateway.Global",
                    "ApiGateway.Global.Export",
                    "ApiGateway.Route",
                    "ApiGateway.Route.Export",
                    "ApiGateway.DynamicRoute",
                    "ApiGateway.DynamicRoute.Export",
                    "ApiGateway.AggregateRoute",
                    "ApiGateway.AggregateRoute.Export",
                    AbpIdentityServerPermissions.ApiResources.Default,
                    IdentityPermissions.UserLookup.Default,
                    IdentityPermissions.Users.Default,
                    TenantManagementPermissions.Tenants.Default}
            );

            await CreateClientAsync(
                "backend-admin-app-client",
                commonScopes.Union(new[] { "BackendAdminAppGateway", "AuthServer", "BackendAdmin" }),
                new[] { "hybrid" },
                commonSecret,
                permissions: new[] { IdentityPermissions.Users.Default, "ProductManagement.Product" },
                redirectUri: "http://localhost:51954/signin-oidc",
                postLogoutRedirectUri: "http://localhost:51954/signout-callback-oidc"
            );
        }

        private async Task<Client> CreateClientAsync(
            string name,
            IEnumerable<string> scopes,
            IEnumerable<string> grantTypes,
            string secret,
            string redirectUri = null,
            string postLogoutRedirectUri = null,
            IEnumerable<string> permissions = null,
            string corsOrigins = null)
        {
            var client = await _clientRepository.FindByCliendIdAsync(name);
            if (client == null)
            {
                client = await _clientRepository.InsertAsync(
                    new Client(
                        _guidGenerator.Create(),
                        name
                    )
                    {
                        ClientName = name,
                        ProtocolType = "oidc",
                        Description = name,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AllowOfflineAccess = true,
                        AbsoluteRefreshTokenLifetime = 31536000, //365 days
                        AccessTokenLifetime = 31536000, //365 days
                        AuthorizationCodeLifetime = 300,
                        IdentityTokenLifetime = 300,
                        RequireConsent = false
                    },
                    autoSave: true
                );
            }

            foreach (var scope in scopes)
            {
                if (client.FindScope(scope) == null)
                {
                    client.AddScope(scope);
                }
            }

            foreach (var grantType in grantTypes)
            {
                if (client.FindGrantType(grantType) == null)
                {
                    client.AddGrantType(grantType);
                }
            }

            if (client.FindSecret(secret) == null)
            {
                client.AddSecret(secret);
            }

            if (redirectUri != null)
            {
                if (client.FindRedirectUri(redirectUri) == null)
                {
                    client.AddRedirectUri(redirectUri);
                }
            }

            if (postLogoutRedirectUri != null)
            {
                if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
                {
                    client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
                }
            }

            if (corsOrigins != null)
            {
                var corsOriginsSplit = corsOrigins.Split(";");
                foreach (var corsOrigin in corsOriginsSplit)
                {
                    if (client.FindCorsOrigin(corsOrigin) == null)
                    {
                        client.AddCorsOrigin(corsOrigin);
                    }
                }
            }

            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(
                    ClientPermissionValueProvider.ProviderName,
                    name,
                    permissions
                );
            }

            return await _clientRepository.UpdateAsync(client);
        }
    }
}
