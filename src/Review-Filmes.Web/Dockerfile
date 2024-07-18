# Use a imagem oficial do .NET SDK 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie os arquivos do projeto
COPY . .

# Restaure as dependências
RUN dotnet restore "./Review-Filmes.Web/Review-Filmes.Web.csproj"

# Compile o projeto
RUN dotnet build "./Review-Filmes.Web/Review-Filmes.Web.csproj" -c Release -o /app/build

# Publique o projeto
RUN dotnet publish "./Review-Filmes.Web/Review-Filmes.Web.csproj" -c Release -o /app/publish

# Use a imagem oficial do .NET runtime para rodar o app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Defina o ponto de entrada para a aplicação
ENTRYPOINT ["dotnet", "Review-Filmes.Web.dll"]
