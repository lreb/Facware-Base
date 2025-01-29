# Infrastructure Layer

The Infrastructure Layer in Clean Architecture should contain:

Data Access (Repositories): Implementations for data access.
Database Context: ORM context for interacting with the database.
Entity Configurations: Schema and relationship configurations for entities.
External Services: Implementations for external services and APIs.
Migrations: Database migrations for schema changes.
Dependency Injection: Registration of services and repositories in the DI container.

Install dotnet-ef
`https://learn.microsoft.com/en-us/ef/core/cli/dotnet`


dotnet-ef.exe migrations add initial -p ..\..\NetCoreBase.Infrastructure.csproj -c ApplicationDbContext -s ..\..\..\NetCoreBase\ -o ..\..\Data\Migrations


# Package Manager Console
## migrations
dotnet-ef.exe migrations add init -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj -o .\Data\Migrations

## update db

dotnet-ef.exe database update -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj

--extra

dotnet-ef.exe migrations list -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj
dotnet-ef.exe migrations remove -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj