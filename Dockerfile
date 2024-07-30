# .NET SDK imajýný kullanarak baþlýyoruz
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Çalýþma dizinini ayarlýyoruz
WORKDIR /app

# Proje dosyasýný kopyalýyoruz
COPY HesapMakinesiii/HesapMakinesiii.csproj ./

# NuGet paketlerini indiriyoruz
RUN dotnet restore

# Projeyi kopyalayýp build ediyoruz
COPY . .
RUN dotnet build -c Release -o /app/build

# Publish iþlemi yapýyoruz
RUN dotnet publish -c Release -o /app/publish

# Ýmajýmýzý çalýþtýracak olan temel imajý seçiyoruz
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HesapMakinesiii.dll"]
