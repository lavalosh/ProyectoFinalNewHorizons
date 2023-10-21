#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Gateway/Muchik.Market.Gateway.API/Muchik.Market.Gateway.API.csproj", "src/Gateway/Muchik.Market.Gateway.API/"]
RUN dotnet restore "src/Gateway/Muchik.Market.Gateway.API/Muchik.Market.Gateway.API.csproj"
COPY . .
WORKDIR "/src/src/Gateway/Muchik.Market.Gateway.API"
RUN dotnet build "Muchik.Market.Gateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Muchik.Market.Gateway.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Muchik.Market.Gateway.API.dll"]