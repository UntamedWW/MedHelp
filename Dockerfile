FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Medhelp/Medhelp.csproj", "Medhelp/"]
COPY ["Medhelp.PersistenceLayer/Medhelp.PersistenceLayer.csproj", "Medhelp.PersistenceLayer/"]
RUN dotnet restore "Medhelp/Medhelp.csproj"
COPY . .
WORKDIR "/src/Medhelp"
RUN dotnet build "Medhelp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medhelp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medhelp.dll"]
