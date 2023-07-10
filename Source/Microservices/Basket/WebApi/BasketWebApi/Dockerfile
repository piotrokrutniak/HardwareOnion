#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Source/Microservices/Basket/WebApi/BasketWebApi/BasketWebApi.csproj", "Source/Microservices/Basket/WebApi/BasketWebApi/"]
COPY ["Source/Microservices/Basket/Core/Application/Application.csproj", "Source/Microservices/Basket/Core/Application/"]
COPY ["Source/Microservices/Basket/Core/Domain/Domain.csproj", "Source/Microservices/Basket/Core/Domain/"]
COPY ["Source/Microservices/Basket/Infrastructure/Infrastructure.Persistence/Infrastructure.Persistence.csproj", "Source/Microservices/Basket/Infrastructure/Infrastructure.Persistence/"]
COPY ["Source/Microservices/Basket/Infrastructure/Infrastructure.Shared/Infrastructure.Shared.csproj", "Source/Microservices/Basket/Infrastructure/Infrastructure.Shared/"]
RUN dotnet restore "Source/Microservices/Basket/WebApi/BasketWebApi/BasketWebApi.csproj"
COPY . .
WORKDIR "/src/Source/Microservices/Basket/WebApi/BasketWebApi"
RUN dotnet build "BasketWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketWebApi.dll"]