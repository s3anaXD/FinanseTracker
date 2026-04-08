# Wersja SDK pasująca do Twojego projektu (TFM: net10.0)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Kopiowanie pliku .csproj i przywracanie zależności (restore)
COPY *.csproj ./
RUN dotnet restore

# Kopiowanie reszty plików i budowanie aplikacji
COPY . ./
RUN dotnet publish -c Release -o out

# Budowanie obrazu uruchomieniowego za pomocą lżejszego obrazu aspnet
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Ustawienie zmiennej środowiskowej portu dla Railway (domyślnie 8080 lub z PORT)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "FinanceTracker.dll"]
