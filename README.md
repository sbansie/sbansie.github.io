Portfolio API;

Gebruikte technieken

.NET 10

ASP.NET Core Web API

Entity Framework Core

SQL Server

Swagger / Swashbuckle

API-structuur

Ik gebruik Controllers met lagen.

De backend is verdeeld in:

Controllers - verwerken HTTP-requests en responses.

Services - bevatten de applicatielogica en DTO-mapping.

Data - bevat PortfolioDbContext voor de database.

Models - bevatten de database-entiteiten.

DTOs - bepalen welke gegevens de API ontvangt en terugstuurt.

De controllers gebruiken de DbContext niet rechtstreeks. Hiervoor worden services gebruikt.

Functionaliteiten

De API ondersteunt volledige CRUD voor:

Projects

Blogposts

Voor beide zijn de volgende endpoints aanwezig:

GET     /api/Projects
GET     /api/Projects/{id}
POST    /api/Projects
PUT     /api/Projects/{id}
DELETE  /api/Projects/{id}

GET     /api/Blogposts
GET     /api/Blogposts/{id}
POST    /api/Blogposts
PUT     /api/Blogposts/{id}
DELETE  /api/Blogposts/{id}

Database

De applicatie gebruikt SQL Server met Entity Framework Core.

De connection string staat in:

appsettings.json

De database wordt aangemaakt met EF Core migrations:

dotnet ef migrations add InitialCreate
dotnet ef database update

De database heet:

PortfolioDb

De gegevens blijven opgeslagen wanneer de API opnieuw wordt gestart.

Project starten

Ga in de terminal naar de map:

PortfolioApi

Voer daarna uit:

dotnet restore
dotnet run

De terminal toont daarna een adres, bijvoorbeeld:

http://localhost:5132

Het poortnummer kan verschillen.

Swagger

Swagger wordt gebruikt om de API te testen.

Open na het starten van de API:

http://localhost:PORT/swagger

Via Swagger heb ik POST, GET, PUT en DELETE getest voor zowel Projects als Blogposts.

Ook heb ik gecontroleerd dat:

gegevens na een herstart blijven bestaan;

een verwijderd of onbekend id een 404 Not Found teruggeeft.

Database migrations

De eerste migration van dit project heet:

InitialCreate

Hiermee worden de tabellen Projects en Blogposts in SQL Server aangemaakt.