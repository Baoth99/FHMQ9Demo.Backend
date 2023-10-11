FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["source/MasterService.WebApi/MasterService.WebApi/MasterService.WebApi.csproj", "source/MasterService.WebApi/MasterService.WebApi/"]
COPY ["source/Utilities/Utilities.csproj", "source/Utilities/"]
RUN dotnet restore "source/MasterService.WebApi/MasterService.WebApi/MasterService.WebApi.csproj"
COPY . .
WORKDIR "/src/source/MasterService.WebApi/MasterService.WebApi"
RUN dotnet build "MasterService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasterService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterService.WebApi.dll"]
