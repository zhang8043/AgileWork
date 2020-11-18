#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["gateways/BackendAdminGateway.Host/BackendAdminGateway.Host.csproj", "gateways/BackendAdminGateway.Host/"]
COPY ["shared/Agile.Shared/Agile.Shared.csproj", "shared/Agile.Shared/"]
RUN dotnet restore "gateways/BackendAdminGateway.Host/BackendAdminGateway.Host.csproj"
COPY . .
WORKDIR "/src/gateways/BackendAdminGateway.Host"
RUN dotnet build "BackendAdminGateway.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendAdminGateway.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendAdminGateway.Host.dll"]