# Infrastructure Layer

The Infrastructure Layer in Clean Architecture should contain:

Data Access (Repositories): Implementations for data access.
Database Context: ORM context for interacting with the database.
Entity Configurations: Schema and relationship configurations for entities.
External Services: Implementations for external services and APIs.
Migrations: Database migrations for schema changes.
Dependency Injection: Registration of services and repositories in the DI container.

## Structure organization
/NetCoreBase.Infrastructure: Contains infrastructure-related code, such as data access and external services.
- /Data: Contains database context and configurations.
- /Repositories: Contains repository implementations.
- /Configurations: Contains infrastructure-related configurations.
- /Migrations: Contains database migrations.
- /Services: Contains infrastructure services.


Install dotnet-ef
`https://learn.microsoft.com/en-us/ef/core/cli/dotnet`


dotnet-ef.exe migrations add initial -p ..\..\NetCoreBase.Infrastructure.csproj -c ApplicationDbContext -s ..\..\..\NetCoreBase\ -o ..\..\Data\Migrations


# Package Manager Console
## migrations
dotnet-ef.exe migrations add init -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj -o .\Data\Migrations

dotnet-ef  migrations add fullentity -s NetCore/NetCoreBase.API/NetCoreBase.API.csproj -p NetCore/NetCoreBase.Infrastructure/NetCoreBase.Infrastructure.csproj -o Data/Migrations/

## update db

-- default

dotnet-ef database update -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj

### Apply migrations

```bash
dotnet-ef database update -s NetCoreBase.API/NetCoreBase.API.csproj -p NetCoreBase.Infrastructure/NetCoreBase.Infrastructure.csproj -- --environment Local
```


--extra

dotnet-ef.exe migrations list -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj
dotnet-ef migrations list -s NetCore/NetCoreBase.API/NetCoreBase.API.csproj  --project NetCore/NetCoreBase.Infrastructure/NetCoreBase.Infrastructure.csproj -v

dotnet-ef migrations remove -s NetCore/NetCoreBase.API/NetCoreBase.API.csproj  --project NetCore/NetCoreBase.Infrastructure/NetCoreBase.Infrastructure.csproj -v


---


Set current environment set ASPNETCORE_ENVIRONMENT=development

Add new Migration: dotnet ef migrations add MyNewMigration

Revert Migration: dotnet ef migrations remove