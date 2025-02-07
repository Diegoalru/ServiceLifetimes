FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceLifetimes/ServiceLifetimes.csproj", "ServiceLifetimes/"]
RUN dotnet restore "ServiceLifetimes/ServiceLifetimes.csproj"
COPY . .
WORKDIR "/src/ServiceLifetimes"
RUN dotnet build "ServiceLifetimes.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceLifetimes.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceLifetimes.dll"]
