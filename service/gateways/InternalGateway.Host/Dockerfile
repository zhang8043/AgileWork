#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["gateways/InternalGateway.Host/InternalGateway.Host.csproj", "gateways/InternalGateway.Host/"]
COPY ["shared/Agile.Shared/Agile.Shared.csproj", "shared/Agile.Shared/"]
RUN dotnet restore "gateways/InternalGateway.Host/InternalGateway.Host.csproj"
COPY . .
WORKDIR "/src/gateways/InternalGateway.Host"
RUN dotnet build "InternalGateway.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InternalGateway.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InternalGateway.Host.dll"]