FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SaluteStocksAPI/SaluteStocksAPI.csproj", "SaluteStocksAPI/"]
RUN dotnet restore "SaluteStocksAPI/SaluteStocksAPI.csproj"
COPY . .
WORKDIR "/src/SaluteStocksAPI"
RUN dotnet build "SaluteStocksAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaluteStocksAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaluteStocksAPI.dll"]
