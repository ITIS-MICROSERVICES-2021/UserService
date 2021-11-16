FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

EXPOSE 80

COPY UserService.Core/*.csproj ./UserService.Core/
COPY UserService.Data/*.csproj ./UserService.Data/
COPY UserService.Features/*.csproj ./UserService.Features/
COPY UserService.WebHost/*.csproj ./UserService.WebHost/
COPY UserService.Test.Unit/*.csproj ./UserService.Test.Unit/

WORKDIR /app/UserService.WebHost
RUN dotnet restore

WORKDIR /app

COPY UserService.Core/ ./UserService.Core/
COPY UserService.Data/ ./UserService.Data/
COPY UserService.Features/ ./UserService.Features/
COPY UserService.WebHost/ ./UserService.WebHost/
COPY UserService.Test.Unit/ ./UserService.Test.Unit/

WORKDIR /app/UserService.WebHost
RUN dotnet publish /property:PublishWithAspNetCoreTargetManifest=false -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

COPY --from=build-env /app/UserService.WebHost/out ./
ENTRYPOINT ["dotnet", "UserService.WebHost.dll"]