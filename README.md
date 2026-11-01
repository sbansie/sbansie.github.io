Portfolio API:

Technieken

.NET 10

ASP.NET Core Web API

Entity Framework Core

SQL Server

Swagger / Swashbuckle

API-structuur

Ik gebruik Controllers met een lagenstructuur:

Controllers: verwerken HTTP-requests en responses.

Services: bevatten de applicatielogica en DTO-mapping.

Data: bevat PortfolioDbContext voor communicatie met SQL Server.

Models: bevatten de database-entiteiten.

DTOs: bepalen welke gegevens via de API worden ontvangen en teruggestuurd.

Functionaliteiten

De API bevat volledige CRUD voor:

Projects

Blogposts

Beschikbare acties:

GET

GET op id

POST

PUT

DELETE

Database

De applicatie gebruikt SQL Server met Entity Framework Core.

De connection string staat in appsettings.json.

De database is aangemaakt met EF Core migrations:

dotnet ef migrations add InitialCreate
dotnet ef database update

Hierdoor blijven gegevens opgeslagen nadat de applicatie opnieuw wordt gestart.

Project starten

Ga naar de map PortfolioApi en voer uit:

dotnet restore
dotnet run

De terminal toont daarna bijvoorbeeld:

Now listening on: http://localhost:5132

Swagger is vervolgens beschikbaar via:

http://localhost:5132/swagger

Het poortnummer kan per computer verschillen.

Endpoints

Projects

GET     /api/Projects
GET     /api/Projects/{id}
POST    /api/Projects
PUT     /api/Projects/{id}
DELETE  /api/Projects/{id}

Blogposts

GET     /api/Blogposts
GET     /api/Blogposts/{id}
POST    /api/Blogposts
PUT     /api/Blogposts/{id}
DELETE  /api/Blogposts/{id}

Testen

De endpoints zijn getest via Swagger UI.

Hierbij heb ik gecontroleerd:

POST maakt nieuwe data aan.

GET haalt de data op.

PUT past bestaande data aan.

Data blijft bestaan na opnieuw starten van de API.

DELETE verwijdert de data.

GET op een verwijderd of onbekend id geeft 404 Not Found.