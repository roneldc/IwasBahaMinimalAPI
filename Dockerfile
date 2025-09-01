# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["IwasBahaAPI.csproj", "./"]
RUN dotnet restore "IwasBahaAPI.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "IwasBahaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Copy SQLite database file if you already have one (optional)
# If not, EF Core will create it at runtime
COPY app.db ./app.db

# Render sets PORT env var, so we honor it
ENV ASPNETCORE_URLS=http://+:${PORT:-5000}

# Expose default port
EXPOSE 5000

ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]