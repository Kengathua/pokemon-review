using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class CountryRepository: ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Country> GetCountries(){
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }
    
        public bool CountryExists(int countryId){
            return _context.Countries.Any(c => c.Id == countryId);
        }
    
        public Country GetCountry(int countryId){
            return _context.Countries.Where(c => c.Id == countryId).FirstOrDefault()
                    ?? throw new KeyNotFoundException($"Country with ID {countryId} not found.");
        }
    
        public Country GetCountryByOwner(int ownerId){
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault()
                    ?? throw new KeyNotFoundException($"Owner with ID {ownerId} not found.");
        }
    }
}