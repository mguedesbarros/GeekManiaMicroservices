#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Catalog/CatalogApiReading/CatalogApiReading.csproj", "src/Catalog/CatalogApiReading/"]
COPY ["src/Broker/EventBus/EventBus/EventBus.csproj", "src/Broker/EventBus/EventBus/"]
COPY ["src/Broker/EventBusRabbitMQ/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Broker/EventBusRabbitMQ/EventBusRabbitMQ/"]
RUN dotnet restore "src/Catalog/CatalogApiReading/CatalogApiReading.csproj"
COPY . .
WORKDIR "/src/src/Catalog/CatalogApiReading"
RUN dotnet build "CatalogApiReading.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogApiReading.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogApiReading.dll"]