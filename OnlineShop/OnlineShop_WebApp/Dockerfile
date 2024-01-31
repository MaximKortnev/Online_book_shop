#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OnlineShop_WebApp/OnlineShop_WebApp.csproj", "OnlineShop_WebApp/"]
COPY ["OnlineShop.Db/OnlineShop.Db.csproj", "OnlineShop.Db/"]
RUN dotnet restore "./OnlineShop_WebApp/./OnlineShop_WebApp.csproj"
COPY . .
WORKDIR "/src/OnlineShop_WebApp"
RUN dotnet build "./OnlineShop_WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OnlineShop_WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShop_WebApp.dll"]