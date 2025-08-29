# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["IwasBahaAPI/IwasBahaAPI.csproj", "IwasBahaAPI/"]
RUN dotnet restore "IwasBahaAPI/IwasBahaAPI.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/IwasBahaAPI"
RUN dotnet publish "IwasBahaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Note: No EXPOSE command needed because Railway handles port mapping dynamically

# Start the API
ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]
