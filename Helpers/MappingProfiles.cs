using AutoMapper;
using PokemonWebAPI.Dto;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}