## Getting started after cloning
```
echo "Restoring packages for PokemonWebAPI..."
cd PokemonWebAPI
dotnet restore
cd ..

echo "Restoring packages for PokemonWebAPI.Tests..."
cd PokemonWebAPI.Tests
dotnet restore
cd ..
```


## PostgresSQL Commands to Set Up Databases and User
```sql
CREATE DATABASE pokemon_db;

CREATE USER pokemon_user WITH SUPERUSER CREATEDB CREATEROLE LOGIN PASSWORD 'pokemon_pass';

ALTER ROLE pokemon_user SET client_encoding TO 'utf8';

ALTER ROLE pokemon_user SET default_transaction_isolation TO 'read committed';

ALTER ROLE pokemon_user SET timezone TO 'UTC';

GRANT ALL PRIVILEGES ON DATABASE pokemon_db TO pokemon_user;
\q
```

## Common Commands
```
#!/usr/bin/env bash

dotnet clean pokemon.sln

dotnet build pokemon.sln

dotnet test PokemonWebAPI.Tests/PokemonWebAPI.Tests.csproj

dotnet run --project PokemonWebAPI/PokemonWebAPI.csproj
```

## Narrow down test runs

### By namespace
```
dotnet test --filter "FullyQualifiedName~PokemonWebAPI.Tests.Controllers"
```

### By class
```
dotnet test --filter "FullyQualifiedName~PokemonWebAPI.Tests.Controllers.PokemonControllerTests"
```

### By test method
```
dotnet test --filter "FullyQualifiedName~PokemonWebAPI.Tests.Controllers.PokemonControllerTests.Test_GetPokemons"
```


## Installing a new package
```
dotnet add PokemonWebAPI.Tests/PokemonWebAPI.csproj package <Package.Name>

dotnet add PokemonWebAPI.Tests/PokemonWebAPI.Tests.csproj package <Package.Name>
```


## Start a new webapi project with unit tests integrated

```
# Create a new solution
dotnet new sln -n pokemon

# Create a new Web API project
dotnet new webapi -n PokemonWebAPI

# Add the Web API project to the solution
dotnet sln pokemon.sln add PokemonWebAPI/PokemonWebAPI.csproj

# Create a new xUnit test project
dotnet new xunit -n PokemonWebAPI.Tests

# Add the test project to the solution
dotnet sln pokemon.sln add PokemonWebAPI.Tests/PokemonWebAPI.Tests.csproj

# Add a project reference to the test project
dotnet add PokemonWebAPI.Tests/PokemonWebAPI.Tests.csproj reference PokemonWebAPI/PokemonWebAPI.csproj
```