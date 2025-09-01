# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY IwasBahaAPI.csproj ./
RUN dotnet restore "IwasBahaAPI.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "IwasBahaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Copy SQLite database
COPY roadstatus.db ./roadstatus.db

# Set ASP.NET Core URL from environment or default to 5000
ENV ASPNETCORE_URLS=http://+:${PORT:-5000}

# Expose port
EXPOSE 5000

ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]
