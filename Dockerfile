# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o /app/publish

# Use a smaller runtime image for final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published app
COPY --from=build /app/publish .

# Copy SQLite database
COPY roadstatus.db ./roadstatus.db

# Expose port (Render sets PORT environment variable)
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "IwasBahaAPI.dll"]