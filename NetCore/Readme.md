


# instructions

Install sdk for local development or runtime for production environment

https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-install?tabs=dotnet8&pivots=os-linux-ubuntu-2404

https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-install?tabs=dotnet8&pivots=os-linux-ubuntu-2204

Linux
https://learn.microsoft.com/en-us/dotnet/core/install/linux-snap-runtime

## restore application packages

https://learn.microsoft.com/es-es/dotnet/core/tools/dotnet-restore

```
dotnet restore
```

## run appliction

before run, apply pending migrations

``` bash
dotnet run --project NetCoreBase.API/NetCoreBase.API.csproj -- --environment Local
```

add packages
```bash
dotnet add --project NetCoreBase.Application/NetCoreBase.Application.csproj package FluentValidation  


dotnet add --project NetCoreBase.Application/NetCoreBase.Application.csproj package Asp.Versioning.Mvc.ApiExplorer --version 8.1.0
```