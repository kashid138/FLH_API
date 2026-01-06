# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy everything inside MinimalAPI folder
COPY . .

RUN dotnet restore MinimalAPI.sln
RUN dotnet publish MinimalAPI.sln -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy published app
COPY --from=build /app .

# Move Docs folder from /app/Minimal_Api/Docs to /app/Docs
RUN mv /app/Minimal_Api/Docs /app/Docs

EXPOSE 8080
ENTRYPOINT ["dotnet", "Minimal_Api.dll"]
