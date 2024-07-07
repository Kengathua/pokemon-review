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
    }
}