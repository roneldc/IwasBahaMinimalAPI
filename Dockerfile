# ----------------------------
# Build stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY IwasBahaAPI/IwasBahaAPI.csproj ./IwasBahaAPI.csproj
RUN dotnet restore ./IwasBahaAPI.csproj

# Copy the rest of the project
COPY IwasBahaAPI/ ./  # includes Program.cs and other files

# Build and publish
RUN dotnet publish ./IwasBahaAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# ----------------------------
# Runtime stage
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Expose port Render expects
EXPOSE 10000

# Render sets PORT environment variable
ENV ASPNETCORE_URLS=http://+:${PORT:-10000}

# Start the application
ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]