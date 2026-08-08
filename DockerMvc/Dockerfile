# Compilación del proyecto
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerMvc.csproj", "."]
RUN dotnet restore "./DockerMvc.csproj"
COPY . .
RUN dotnet build "./DockerMvc.csproj" -c $BUILD_CONFIGURATION -o /app/build
# Publicar el proyecto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerMvc.csproj" \
-c $BUILD_CONFIGURATION \
-o /app/publish \
/p:UseAppHost=false
# Imagen final para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerMvc.dll"]