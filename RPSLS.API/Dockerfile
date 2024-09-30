#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RPSLS.API/RPSLS.API.csproj", "RPSLS.API/"]
COPY ["RPSLS.Application/RPSLS.Application.csproj", "RPSLS.Application/"]
COPY ["RPSLS.Data/RPSLS.Data.csproj", "RPSLS.Data/"]
COPY ["RPSLS.Models/RPSLS.Models.csproj", "RPSLS.Models/"]
RUN dotnet restore "./RPSLS.API/RPSLS.API.csproj"
COPY . .
WORKDIR "/src/RPSLS.API"
RUN dotnet build "./RPSLS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RPSLS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RPSLS.API.dll"]