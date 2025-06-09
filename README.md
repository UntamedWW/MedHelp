# Medhelp

Medhelp to aplikacja webowa typu API służąca do zarządzania informacjami o lekach, substancjach czynnych, specjalizacjach medycznych i innych powiązanych danych. Projekt wykorzystuje bazę danych PostgreSQL oraz umożliwia podgląd i zarządzanie bazą przez pgAdmin.

## Infrastruktura i architektura

Projekt został zbudowany w oparciu o wzorzec **Onion Architecture**, z zachowaniem zasad **SOLID** oraz podejścia **Clean Code**. Struktura rozwiązania opiera się na kilku warstwach, z których każda ma jasno określoną odpowiedzialność:

- **Medhelp.Domain** – warstwa domenowa, zawiera encje i logikę biznesową.
- **Medhelp.Contracts** – kontrakty, DTO oraz interfejsy wykorzystywane do komunikacji między warstwami.
- **Medhelp.Exceptions** – definiuje wyjątki specyficzne dla domeny i aplikacji.
- **Medhelp.Repositories** – interfejsy dostępu do danych.
- **Medhelp.PersistenceLayer** – konfiguracja Entity Framework, migracje oraz implementacja dostępu do bazy danych PostgreSQL.
- **Medhelp.Services.Abstractions** – interfejsy usług biznesowych.
- **Medhelp.Services** – implementacje logiki biznesowej oraz serwisów aplikacyjnych.
- **Medhelp** – projekt główny (API), udostępniający endpointy HTTP.

Dzięki takiej strukturze kod jest łatwy w utrzymaniu, testowaniu i rozbudowie.

## Wymagania

- Docker i Docker Compose
- .NET 8 SDK (jeśli chcesz uruchomić lokalnie bez Dockera)

## Jak uruchomić projekt

1. **Sklonuj repozytorium i przejdź do katalogu projektu:**

   ```
   git clone <adres_repozytorium>
   cd Medhelp
   ```

2. **Uruchom wszystkie usługi za pomocą Docker Compose:**

   ```
   docker-compose up --build
   ```

   Spowoduje to uruchomienie:

   - API (`medhelp-api`) na porcie `8080`
   - Bazy danych PostgreSQL na porcie `5432`
   - pgAdmin na porcie `5050`

3. **Dostęp do API:**

   - Swagger UI: [http://localhost:8080/swagger](http://localhost:8080/swagger)

4. **Dostęp do bazy danych przez pgAdmin:**
   - Wejdź na [http://localhost:5050](http://localhost:5050)
   - Zaloguj się:
     - Email: `admin@domain.com`
     - Hasło: `password`
   - Dodaj nowy serwer:
     - Host: `med-postgresql`
     - Użytkownik: `admin`
     - Hasło: `StrongPassword123`
     - Baza: `medhelp`

## Technologie

- **ASP.NET Core** – backend API
- **PostgreSQL** – baza danych
- **pgAdmin** – narzędzie do zarządzania bazą danych

## Uwagi

- Przy pierwszym uruchomieniu baza danych zostanie automatycznie zainicjalizowana i zaktualizowana do najnowszej wersji migracji.
- Wszystkie ustawienia środowiskowe znajdują się w pliku `docker-compose.yml`.
