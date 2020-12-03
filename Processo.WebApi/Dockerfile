FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine

COPY ./bin/Release/netcoreapp3.1/publish/  .

ENTRYPOINT ["dotnet", "Processo.WebApi.dll"]