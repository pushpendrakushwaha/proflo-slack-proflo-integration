FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY ./ProfloSlackIntegration ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /ProfloSlackIntegration
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","ProfloSlackIntegration.dll"]
