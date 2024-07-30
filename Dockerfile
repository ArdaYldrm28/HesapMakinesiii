# .NET SDK imaj�n� kullanarak ba�l�yoruz
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# �al��ma dizinini ayarl�yoruz
WORKDIR /app

# Proje dosyas�n� kopyal�yoruz
COPY HesapMakinesiii/HesapMakinesiii.csproj ./

# NuGet paketlerini indiriyoruz
RUN dotnet restore

# Projeyi kopyalay�p build ediyoruz
COPY . .
RUN dotnet build -c Release -o /app/build

# Publish i�lemi yap�yoruz
RUN dotnet publish -c Release -o /app/publish

# �maj�m�z� �al��t�racak olan temel imaj� se�iyoruz
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HesapMakinesiii.dll"]
