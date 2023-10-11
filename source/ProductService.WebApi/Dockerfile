FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["source/ProductService.WebApi/ProductService.WebApi/ProductService.WebApi.csproj", "source/ProductService.WebApi/ProductService.WebApi/"]
COPY ["source/Utilities/Utilities.csproj", "source/Utilities/"]
RUN dotnet restore "source/ProductService.WebApi/ProductService.WebApi/ProductService.WebApi.csproj"
COPY . .
WORKDIR "/src/source/ProductService.WebApi/ProductService.WebApi"
RUN dotnet build "ProductService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.WebApi.dll"]
