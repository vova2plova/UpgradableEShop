# Build stage

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
RUN useradd -ms /bin/bash CatalogService_app
USER CatalogService_app
WORKDIR /CatalogService_app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /CatalogService


# Restore CatalogService.Domain/CatalogService.Domain.csproj
COPY ["CatalogService.Domain/CatalogService.Domain.csproj", "CatalogService.Domain/"]
RUN dotnet restore "./CatalogService.Domain/CatalogService.Domain.csproj"

# Restore CatalogService.Infrastructure/CatalogService.Infrastructure.csproj
COPY ["CatalogService.Infrastructure/CatalogService.Infrastructure.csproj", "CatalogService.Infrastructure/"]
RUN dotnet restore "./CatalogService.Infrastructure/CatalogService.Infrastructure.csproj"

# Restore CatalogService.Application
COPY ["CatalogService.Application/CatalogService.Application.csproj", "CatalogService.Application/"]
RUN dotnet restore "./CatalogService.Application/CatalogService.Application.csproj"

# Restore CatalogService.Database
COPY ["CatalogService.Database/CatalogService.Database.csproj", "CatalogService.Database/"]
RUN dotnet restore "./CatalogService.Database/CatalogService.Database.csproj"

# Restore CatalogService/CatalogService.csproj
COPY ["CatalogService/CatalogService.csproj", "CatalogService/"]
RUN dotnet restore "./CatalogService/CatalogService.csproj"

COPY . .
WORKDIR "/CatalogService/CatalogService"
RUN dotnet build "./CatalogService.csproj" -c $BUILD_CONFIGURATION -o /CatalogService_app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CatalogService.csproj" -c $BUILD_CONFIGURATION -o /CatalogService_app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /CatalogService_app
COPY --from=publish /CatalogService_app/publish .
ENTRYPOINT [ "dotnet", "CatalogService.dll" ]