using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWebAPI.Dto;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;

        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository owneRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ownerRepository = owneRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetOwners()
        {
            var pokemons = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}