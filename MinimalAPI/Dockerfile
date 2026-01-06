 # --------------------------
# Stage 1: Build
# --------------------------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy solution
COPY ["MinimalAPI/MinimalAPI.sln", "./"]

# Copy project folders
COPY ["MinimalAPI/Minimal_Api/", "./Minimal_Api/"]
COPY ["Application/", "./Application/"]
COPY ["DataAccess/", "./DataAccess/"]
COPY ["Domain/", "./Domain/"]

# Ensure Docs folder is copied
COPY ["MinimalAPI/Minimal_Api/Docs/", "./Minimal_Api/Docs/"]

# Publish the solution
RUN dotnet publish MinimalAPI.sln -c Release -o /app

# --------------------------
# Stage 2: Runtime
# --------------------------
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy published app from build stage
COPY --from=build /app .

# Expose port
EXPOSE 8080

# Entry point
ENTRYPOINT ["dotnet", "Minimal_Api.dll"]

