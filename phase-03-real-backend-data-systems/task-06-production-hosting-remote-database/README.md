# Task 06 - Production Hosting & Remote Database

## Objective

Deploy the ASP.NET Core Web API to a production hosting environment and connect it to a remote SQL Server database.


# Hosting Information

- Hosting Provider: MonsterASP.NET
- Runtime: .NET 8
- HTTPS Enabled: Yes

### Live API

https://rowida-trainingcenter.runasp.net

### Live Swagger

https://rowida-trainingcenter.runasp.net/swagger


# Production Database

The application uses a remote SQL Server database hosted on MonsterASP.NET.

The production connection string is stored securely using MonsterASP.NET Environment Variables and is **not committed to GitHub**.

Database schema was created by applying Entity Framework Core migrations.


# Deployment Steps

1. Completed and tested the API locally.
2. Created a MonsterASP.NET hosting account.
3. Created a remote SQL Server database.
4. Configured the production connection string.
5. Applied EF Core migrations to the remote database.
6. Published the ASP.NET Core Web API.
7. Verified the live API using Swagger and Postman.


# Production Safety

- No production passwords are committed to GitHub.
- Database credentials are hidden in screenshots.
- Production secrets are stored using hosting environment variables.
- Remote SQL credentials are not included in the repository.


# Deployment Evidence

The Deployment Evidence folder in Drive contains screenshots for:

- Local Swagger
- Local Database
- Hosting Dashboard
- Website URL
- Remote Database
- Environment Variables
- Remote Tables
- Live Swagger
- Live GET Endpoint
- Live POST Endpoint
- GitHub Repository Safety Check


# Known Deployment Issues

During deployment the following issues were encountered:

- Swagger initially returned 404 because it was enabled only in the Development environment.
- The application was republished after enabling Swagger for Production.
- The published files were uploaded to the hosting root directory.
- Remote database migrations were successfully applied after configuring the production connection string.


# Result

The API is successfully deployed and accessible online.

The application can:

- Read data from the remote SQL Server database.
- Create new records using POST endpoints.
- Serve Swagger documentation.
- Connect securely without exposing production credentials.