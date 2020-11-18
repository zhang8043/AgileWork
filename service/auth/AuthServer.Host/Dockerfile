#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["auth/AuthServer.Host/AuthServer.Host.csproj", "auth/AuthServer.Host/"]
COPY ["modules/tenant-management/Agile.Abp.MultiTenancy/Agile.Abp.MultiTenancy.csproj", "modules/tenant-management/Agile.Abp.MultiTenancy/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.Application.Contracts/Agile.Abp.IdentityServer.Application.Contracts.csproj", "modules/identityServer/Agile.Abp.IdentityServer.Application.Contracts/"]
COPY ["modules/account/Agile.Abp.Account.Domain/Agile.Abp.Account.Domain.csproj", "modules/account/Agile.Abp.Account.Domain/"]
COPY ["modules/account/Agile.Abp.Account.Domain.Shared/Agile.Abp.Account.Domain.Shared.csproj", "modules/account/Agile.Abp.Account.Domain.Shared/"]
COPY ["shared/Agile.Shared/Agile.Shared.csproj", "shared/Agile.Shared/"]
COPY ["modules/identity/Agile.Abp.PermissionManagement.Domain.Identity/Agile.Abp.PermissionManagement.Domain.Identity.csproj", "modules/identity/Agile.Abp.PermissionManagement.Domain.Identity/"]
COPY ["modules/permissions-management/Agile.Abp.PermissionManagement.Domain/Agile.Abp.PermissionManagement.Domain.csproj", "modules/permissions-management/Agile.Abp.PermissionManagement.Domain/"]
COPY ["modules/tenant-management/Agile.Abp.MultiTenancy.DbFinder/Agile.Abp.MultiTenancy.DbFinder.csproj", "modules/tenant-management/Agile.Abp.MultiTenancy.DbFinder/"]
COPY ["modules/identityServer/Agile.Abp.IdentityServer.SmsValidator/Agile.Abp.IdentityServer.SmsValidator.csproj", "modules/identityServer/Agile.Abp.IdentityServer.SmsValidator/"]
RUN dotnet restore "auth/AuthServer.Host/AuthServer.Host.csproj"
COPY . .
WORKDIR "/src/auth/AuthServer.Host"
RUN dotnet build "AuthServer.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthServer.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.Host.dll"]