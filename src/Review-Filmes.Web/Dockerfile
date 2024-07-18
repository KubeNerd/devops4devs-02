# Use the official .NET image for the build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project files
COPY . .

# Restore dependencies
RUN dotnet restore "./Review-Filmes.Web/Review-Filmes.Web.csproj"

# Build the project
RUN dotnet build "./Review-Filmes.Web/Review-Filmes.Web.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "./Review-Filmes.Web/Review-Filmes.Web.csproj" -c Release -o /app/publish

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Review-Filmes.Web.dll"]
