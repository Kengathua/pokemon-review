using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
    }
}