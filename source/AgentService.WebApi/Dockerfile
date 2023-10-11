FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["source/AgentService.WebApi/AgentService.WebApi/AgentService.WebApi.csproj", "source/AgentService.WebApi/AgentService.WebApi/"]
COPY ["source/Utilities/Utilities.csproj", "source/Utilities/"]
RUN dotnet restore "source/AgentService.WebApi/AgentService.WebApi/AgentService.WebApi.csproj"
COPY . .
WORKDIR "/src/source/AgentService.WebApi/AgentService.WebApi"
RUN dotnet build "AgentService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgentService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgentService.WebApi.dll"]
