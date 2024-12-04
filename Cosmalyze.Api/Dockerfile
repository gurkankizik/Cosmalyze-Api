FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Cosmalyze.Api/Cosmalyze.Api.csproj", "Cosmalyze.Api/"]
RUN dotnet restore "Cosmalyze.Api/Cosmalyze.Api.csproj"
COPY . .
WORKDIR "/src/Cosmalyze.Api"
RUN dotnet build "Cosmalyze.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cosmalyze.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cosmalyze.Api.dll"]
