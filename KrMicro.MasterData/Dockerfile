FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KrMicro.MasterData/KrMicro.MasterData.csproj", "KrMicro.MasterData/"]
RUN dotnet restore "KrMicro.MasterData/KrMicro.MasterData.csproj"
COPY . .
WORKDIR "/src/KrMicro.MasterData"
RUN dotnet build "KrMicro.MasterData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KrMicro.MasterData.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KrMicro.MasterData.dll"]
