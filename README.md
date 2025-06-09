## MedHelp – OTC Medicine Data Management API

**MedHelp** is a backend-only web application that automates the collection, normalisation, storage and delivery of data on over-the-counter medicines, active substances, medical specialties and related classifications.
Originally developed as an engineering-degree project, the system leverages **PostgreSQL** for persistence and **pgAdmin** for graphical database administration.

---

\### Architecture

The solution follows **Onion Architecture**, reinforced by **SOLID** principles and Clean-Code conventions. Each layer has a single, well-defined responsibility:

| Project / Layer                   | Purpose                                                   |
| --------------------------------- | --------------------------------------------------------- |
| **Medhelp.Domain**                | Core domain entities and business rules                   |
| **Medhelp.Contracts**             | DTOs and service interfaces                               |
| **Medhelp.Exceptions**            | Domain- and app-specific exceptions                       |
| **Medhelp.Repositories**          | Repository abstractions                                   |
| **Medhelp.PersistenceLayer**      | EF Core configuration, migrations and PostgreSQL adapters |
| **Medhelp.Services.Abstractions** | Service contracts                                         |
| **Medhelp.Services**              | Business-logic and scraping implementations               |
| **Medhelp (API)**                 | ASP.NET Core project exposing HTTP/JSON endpoints         |

This structure keeps business logic isolated from infrastructure, simplifies unit testing and makes future extensions or technology swaps straightforward.

---

\### Requirements

* **Docker** + **Docker Compose** (recommended)
* Alternatively: **.NET 8 SDK**, **PostgreSQL 16**, **pgAdmin 6**

---

\### Quick Start (Docker)

```
# inside the unpacked MedHelp folder
docker compose up --build -d
```

| Service          | Host Port | Description                      |
| ---------------- | --------- | -------------------------------- |
| `medhelp-api`    | **8080**  | ASP.NET Core 8 with Swagger docs |
| `med-postgresql` | **5432**  | PostgreSQL database              |
| `pgadmin4`       | **5050**  | pgAdmin web console              |

*Swagger UI:* [http://localhost:8080/swagger](http://localhost:8080/swagger)
<a href="https://flutter.dev/">
  <h1 align="center">
    <picture>
      <img alt="Swagger" src="https://github.com/user-attachments/assets/c53ce8bf-fe98-4522-b0ed-690176f08f6c">
    </picture>
  </h1>
</a>

*pgAdmin:* [http://localhost:5050](http://localhost:5050)  →  login `admin@domain.com` / `password`
Add a new server: **Host** `med-postgresql`, **User** `admin`, **Password** `StrongPassword123`, **DB** `medhelp`.
<a href="https://flutter.dev/">
  <h1 align="center">
    <picture>
      <img alt="pgAdmin" src="https://github.com/user-attachments/assets/9151f83c-0008-4868-b683-9b799c59b298">
    </picture>
  </h1>
</a>

---

\### Running Locally (without Docker)

1. Install .NET 8 SDK and PostgreSQL 16.
2. Create database `medhelp` and user `admin` / `StrongPassword123`.
3. Run migrations:

   ```
   dotnet ef database update --project Medhelp --startup-project Medhelp
   ```
4. Build and launch:

   ```
   dotnet run --project Medhelp
   ```

   Swagger is served at `http://localhost:8080/swagger`.

---

\### Technologies

* **ASP.NET Core 8** – REST API and dependency-injection host
* **Entity Framework Core** – ORM and migrations
* **PostgreSQL 16** – relational data store
* **pgAdmin 6** – database administration GUI
* **Docker / Docker Compose** – repeatable multi-container environment

---

\### Notes

* On first start-up the database is seeded and updated to the latest EF Core migration automatically.
* Environment variables (passwords, ports) are centralised in `docker-compose.yml`; adjust as needed for staging or production.
* The codebase served as the author’s engineering thesis and is prepared for future research work, e.g. NLP-based symptom analysis, price-tracking modules or FHIR integration.
