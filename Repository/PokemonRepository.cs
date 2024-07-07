using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemonId){
            return _context.Pokemon.Any(o => o.Id == pokemonId);
        }

        public Pokemon GetPokemon(int pokemonId)
        {
            return _context.Pokemon.SingleOrDefault(o => o.Id == pokemonId) 
                   ?? throw new KeyNotFoundException($"Pokemon with ID {pokemonId} not found.");
        }
    
        public decimal GetPokemonRating(int pokemonId) {
            var review = _context.Reviews.Where(r => r.Pokemon.Id == pokemonId);
            if (!review.Any()) {
                return 0;
            }
        
            return (decimal)review.Sum(r => r.Rating) / review.Count();
        }
    }
}