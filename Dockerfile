# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY IwasBahaAPI/IwasBahaAPI.csproj ./
RUN dotnet restore ./IwasBahaAPI.csproj

# Copy project files
COPY IwasBahaAPI/ ./  # all project files

# Publish
RUN dotnet publish ./IwasBahaAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Expose Render port
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:${PORT:-10000}

ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]
