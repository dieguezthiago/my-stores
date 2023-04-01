FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

#solution projects
COPY My.Stores/My.Stores.Domain/My.Stores.Domain.csproj ./My.Stores/My.Stores.Domain/
COPY My.Stores/My.Stores.Infrastructure/My.Stores.Infrastructure.csproj ./My.Stores/My.Stores.Infrastructure/
COPY My.Stores/My.Stores.Api/My.Stores.Api.csproj ./My.Stores/My.Stores.Api/
#test projects
COPY My.Stores/My.Stores.Domain.Unit.Tests/My.Stores.Domain.Unit.Tests.csproj ./My.Stores/My.Stores.Domain.Unit.Tests/
COPY My.Stores/My.Stores.Infrastructure.Unit.Tests/My.Stores.Infrastructure.Unit.Tests.csproj ./My.Stores/My.Stores.Infrastructure.Unit.Tests/
#solution
COPY My.Stores/My.Stores.sln ./My.Stores/

RUN dotnet restore My.Stores/My.Stores.sln

COPY . .

RUN dotnet test "My.Stores/My.Stores.Domain.Unit.Tests/"
RUN dotnet test "My.Stores/My.Stores.Infrastructure.Unit.Tests"
RUN dotnet publish "My.Stores/My.Stores.Api/My.Stores.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

#ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5000
#ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
#ENV ASPNETCORE_HTTPS_PORT=5001
#EXPOSE 5001
EXPOSE 5000
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "My.Stores.Api.dll"]