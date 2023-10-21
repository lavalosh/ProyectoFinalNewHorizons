#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Pay/Muchik.Market.Pay.API/Muchik.Market.Pay.API.csproj", "src/Pay/Muchik.Market.Pay.API/"]
RUN dotnet restore "src/Pay/Muchik.Market.Pay.API/Muchik.Market.Pay.API.csproj"
COPY . .
WORKDIR "/src/src/Pay/Muchik.Market.Pay.API"
RUN dotnet build "Muchik.Market.Pay.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Muchik.Market.Pay.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Muchik.Market.Pay.API.dll"]