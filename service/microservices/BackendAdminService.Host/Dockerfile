#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["microservices/BackendAdminService.Host/BackendAdmin.Host.csproj", "microservices/BackendAdminService.Host/"]
COPY ["modules/setting-management/Agile.Abp.SettingManagement.Application/Agile.Abp.SettingManagement.Application.csproj", "modules/setting-management/Agile.Abp.SettingManagement.Application/"]
COPY ["modules/setting-management/Agile.Abp.SettingManagement.Application.Contracts/Agile.Abp.SettingManagement.Application.Contracts.csproj", "modules/setting-management/Agile.Abp.SettingManagement.Application.Contracts/"]
COPY ["modules/identity/Agile.Abp.Identity.Application/Agile.Abp.Identity.Application.csproj", "modules/identity/Agile.Abp.Identity.Application/"]
COPY ["modules/identity/Agile.Abp.Identity.Domain/Agile.Abp.Identity.Domain.csproj", "modules/identity/Agile.Abp.Identity.Domain/"]
COPY ["modules/identity/Agile.Abp.Identity.Domain.Shared/Agile.Abp.Identity.Domain.Shared.csproj", "modules/identity/Agile.Abp.Identity.Domain.Shared/"]
COPY ["modules/identity/Agile.Abp.Identity.Application.Contracts/Agile.Abp.Identity.Application.Contracts.csproj", "modules/identity/Agile.Abp.Identity.Application.Contracts/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.EntityFrameworkCore/Agile.Abp.IdentityServer.EntityFrameworkCore.csproj", "modules/identityServer/Agile.Abp.IdentityServer.EntityFrameworkCore/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.Domain/Agile.Abp.IdentityServer.Domain.csproj", "modules/identityServer/Agile.Abp.IdentityServer.Domain/"]
COPY ["modules/file-management/Agile.Abp.FileManagement.Application.Contracts/Agile.Abp.FileManagement.Application.Contracts.csproj", "modules/file-management/Agile.Abp.FileManagement.Application.Contracts/"]
COPY ["modules/file-management/Agile.Abp.FileManagement.Domain.Shared/Agile.Abp.FileManagement.Domain.Shared.csproj", "modules/file-management/Agile.Abp.FileManagement.Domain.Shared/"]
COPY ["modules/account/Agile.Abp.Account.Application/Agile.Abp.Account.Application.csproj", "modules/account/Agile.Abp.Account.Application/"]
COPY ["framework/Agile.Abp.Settings/Agile.Abp.Settings.csproj", "framework/Agile.Abp.Settings/"]
COPY ["modules/account/Agile.Abp.Account.Domain/Agile.Abp.Account.Domain.csproj", "modules/account/Agile.Abp.Account.Domain/"]
COPY ["modules/account/Agile.Abp.Account.Domain.Shared/Agile.Abp.Account.Domain.Shared.csproj", "modules/account/Agile.Abp.Account.Domain.Shared/"]
COPY ["modules/account/Agile.Abp.Account.Application.Contracts/Agile.Abp.Account.Application.Contracts.csproj", "modules/account/Agile.Abp.Account.Application.Contracts/"]
COPY ["modules/backend-admin/BackendAdmin.HttpApi/BackendAdmin.HttpApi.csproj", "modules/backend-admin/BackendAdmin.HttpApi/"]
COPY ["modules/backend-admin/BackendAdmin.Application.Contracts/BackendAdmin.Application.Contracts.csproj", "modules/backend-admin/BackendAdmin.Application.Contracts/"]
COPY ["modules/backend-admin/BackendAdmin.Domain.Shared/BackendAdmin.Domain.Shared.csproj", "modules/backend-admin/BackendAdmin.Domain.Shared/"]
COPY ["modules/account/Agile.Abp.Account.HttpApi/Agile.Abp.Account.HttpApi.csproj", "modules/account/Agile.Abp.Account.HttpApi/"]
COPY ["modules/tenant-management/Agile.Abp.TenantManagement.Application/Agile.Abp.TenantManagement.Application.csproj", "modules/tenant-management/Agile.Abp.TenantManagement.Application/"]
COPY ["modules/tenant-management/Agile.Abp.TenantManagement.Application.Contracts/Agile.Abp.TenantManagement.Application.Contracts.csproj", "modules/tenant-management/Agile.Abp.TenantManagement.Application.Contracts/"]
COPY ["modules/tenant-management/Agile.Abp.MultiTenancy/Agile.Abp.MultiTenancy.csproj", "modules/tenant-management/Agile.Abp.MultiTenancy/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.HttpApi/Agile.Abp.IdentityServer.HttpApi.csproj", "modules/identityServer/Agile.Abp.IdentityServer.HttpApi/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.Application.Contracts/Agile.Abp.IdentityServer.Application.Contracts.csproj", "modules/identityServer/Agile.Abp.IdentityServer.Application.Contracts/"]
COPY ["modules/identity/Agile.Abp.Identity.HttpApi/Agile.Abp.Identity.HttpApi.csproj", "modules/identity/Agile.Abp.Identity.HttpApi/"]
COPY ["modules/tenant-management/Agile.Abp.TenantManagement.HttpApi/Agile.Abp.TenantManagement.HttpApi.csproj", "modules/tenant-management/Agile.Abp.TenantManagement.HttpApi/"]
COPY ["modules/backend-admin/BackendAdmin.Application/BackendAdmin.Application.csproj", "modules/backend-admin/BackendAdmin.Application/"]
COPY ["modules/backend-admin/BackendAdmin.Domain/BackendAdmin.Domain.csproj", "modules/backend-admin/BackendAdmin.Domain/"]
COPY ["modules/audit-logging/Agile.Abp.Auditing.HttpApi/Agile.Abp.Auditing.HttpApi.csproj", "modules/audit-logging/Agile.Abp.Auditing.HttpApi/"]
COPY ["modules/audit-logging/Agile.Abp.Auditing.Application.Contracts/Agile.Abp.Auditing.Application.Contracts.csproj", "modules/audit-logging/Agile.Abp.Auditing.Application.Contracts/"]
COPY ["modules/identity/Agile.Abp.Identity.EntityFrameworkCore/Agile.Abp.Identity.EntityFrameworkCore.csproj", "modules/identity/Agile.Abp.Identity.EntityFrameworkCore/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.Application/Agile.Abp.IdentityServer.Application.csproj", "modules/identityServer/Agile.Abp.IdentityServer.Application/"]
COPY ["shared/Agile.Shared/Agile.Shared.csproj", "shared/Agile.Shared/"]
COPY ["modules/setting-management/Agile.Abp.SettingManagement.HttpApi/Agile.Abp.SettingManagement.HttpApi.csproj", "modules/setting-management/Agile.Abp.SettingManagement.HttpApi/"]
COPY ["modules/audit-logging/Agile.Abp.Auditing.Application/Agile.Abp.Auditing.Application.csproj", "modules/audit-logging/Agile.Abp.Auditing.Application/"]
COPY ["modules/backend-admin/BackendAdmin.EntityFrameworkCore/BackendAdmin.EntityFrameworkCore.csproj", "modules/backend-admin/BackendAdmin.EntityFrameworkCore/"]
COPY ["modules/tenant-management/Agile.Abp.MultiTenancy.DbFinder/Agile.Abp.MultiTenancy.DbFinder.csproj", "modules/tenant-management/Agile.Abp.MultiTenancy.DbFinder/"]
RUN dotnet restore "microservices/BackendAdminService.Host/BackendAdmin.Host.csproj"
COPY . .
WORKDIR "/src/microservices/BackendAdminService.Host"
RUN dotnet build "BackendAdmin.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendAdmin.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendAdmin.Host.dll"]