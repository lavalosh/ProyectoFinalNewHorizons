#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Invoice/Muchik.Market.Invoice.API/Muchik.Market.Invoice.API.csproj", "src/Invoice/Muchik.Market.Invoice.API/"]
RUN dotnet restore "src/Invoice/Muchik.Market.Invoice.API/Muchik.Market.Invoice.API.csproj"
COPY . .
WORKDIR "/src/src/Invoice/Muchik.Market.Invoice.API"
RUN dotnet build "Muchik.Market.Invoice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Muchik.Market.Invoice.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Muchik.Market.Invoice.API.dll"]