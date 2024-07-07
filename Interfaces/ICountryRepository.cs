using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        bool CountryExists(int countryId);
        Country GetCountry(int countryId);
    }
}