FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY Petshop.sln .
COPY Petshop.Domain/Petshop.Domain.csproj Petshop.Domain/
COPY Petshop.Application/Petshop.Application.csproj Petshop.Application/
COPY Petshop.Infrastructure/Petshop.Infrastructure.csproj Petshop.Infrastructure/
COPY Petshop.API/Petshop.API.csproj Petshop.API/

RUN dotnet restore

COPY . .

RUN dotnet publish Petshop.API/Petshop.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Petshop.API.dll"]