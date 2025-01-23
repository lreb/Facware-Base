


dotnet-ef.exe migrations add initial -p ..\..\NetCoreBase.Infrastructure.csproj -c ApplicationDbContext -s ..\..\..\NetCoreBase\ -o ..\..\Data\Migrations


# Package Manager Console
## migrations
dotnet-ef.exe migrations add init -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj -o .\Data\Migrations

## update db

dotnet-ef.exe database update -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj

--extra

dotnet-ef.exe migrations list -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj
dotnet-ef.exe migrations remove -s .\NetCoreBase\NetCoreBase.csproj -p .\NetCoreBase.Infrastructure\NetCoreBase.Infrastructure.csproj