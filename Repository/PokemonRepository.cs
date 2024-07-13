using Microsoft.AspNetCore.Mvc;
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
    
        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon) {
            var owner = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            if (owner == null) {
                throw new KeyNotFoundException($"Owner with ID {ownerId} not found.");
            }

            if (category == null) {
                throw new KeyNotFoundException($"Category with ID {categoryId} not found.");
            }

            var pokemonOwner  = new PokemonOwner()
            {
                Owner = owner!,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory  = new PokemonCategory()
            {
                Category = category!,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }
    
        public bool Save(){
            var saved = _context.SaveChanges();
            return saved > 0? true: false;
        }
    }
}