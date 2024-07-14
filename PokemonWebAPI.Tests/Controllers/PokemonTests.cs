using AutoMapper;
using FluentAssertions;
using FakeItEasy;
using PokemonWebAPI.Controllers;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;
using PokemonWebAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace PokemonWebAPI.Tests.Controllers
{
    public class PokemonControllerTests
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonControllerTests()
            {
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public  void Test_GetPokemons(){
            var pokemons = A.Fake<ICollection<Pokemon>>();
            var serializedPokemons = A.Fake<List<PokemonDto>>();
            A.CallTo(() => _pokemonRepository.GetPokemons()).Returns(pokemons);
            var _controller = new PokemonController(_pokemonRepository, _mapper);

            var result = _controller.GetPokemons();

            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public  void Test_CreatePokemon()
        {
            // Arrange
            var ownerId = 1;
            var catId = 1;
            var pokemonDto = new PokemonDto();
            var pokemon = new Pokemon();

            A.CallTo(() => _mapper.Map<Pokemon>(pokemonDto)).Returns(pokemon);
            A.CallTo(() => _pokemonRepository.CreatePokemon(ownerId, catId, pokemon)).Returns(true);

            var controller = new PokemonController(_pokemonRepository, _mapper);

            // Act
            var result = controller.CreatePokemon(ownerId, catId, pokemonDto);

            // Assert
            result.Should().BeOfType(typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be("Successfully created");
        }
    }
}