#!/usr/bin/env bash

dotnet clean pokemon.sln

dotnet build pokemon.sln

dotnet test PokemonWebAPI.Tests/PokemonWebAPI.Tests.csproj

dotnet run --project PokemonWebAPI/PokemonWebAPI.csproj
