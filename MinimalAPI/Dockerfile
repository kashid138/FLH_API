# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution and all project files
COPY . .
RUN dotnet restore MinimalAPI.sln
RUN dotnet publish MinimalAPI.sln -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080

# Entry point: point to your main project DLL
ENTRYPOINT ["dotnet", "Minimal_Api.dll"]
