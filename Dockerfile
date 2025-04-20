# Base para tiempo de ejecución: imagen ligera que solo contiene el runtime de ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app                # Establece el directorio de trabajo dentro del contenedor
EXPOSE 80                   
#Informa que el contenedor escuchará en el puerto HTTP
EXPOSE 443                  
# Informa que el contenedor escuchará en el puerto HTTPS

# Etapa de construcción: imagen más pesada con el SDK completo para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Primero copia solo el archivo de proyecto para aprovechar el caché de capas de Docker
COPY ["AmadeusAPI.csproj", "./"]
# Restaura los paquetes NuGet (se ejecuta solo si cambia el .csproj)
RUN dotnet restore "AmadeusAPI.csproj"
# Ahora copia todo el código fuente
COPY . .
WORKDIR "/src"
# Compila la aplicación en modo Release
RUN dotnet build "AmadeusAPI.csproj" -c Release -o /app/build

# Etapa de publicación: prepara los archivos para producción
FROM build AS publish
# Publica la aplicación (optimizada para producción)
RUN dotnet publish "AmadeusAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final: copia solo los archivos necesarios de la etapa de publicación
FROM base AS final
WORKDIR /app
# Copia los archivos publicados desde la etapa "publish"
COPY --from=publish /app/publish .
# Define el comando que se ejecutará al iniciar el contenedor
ENTRYPOINT ["dotnet", "AmadeusAPI.dll"]