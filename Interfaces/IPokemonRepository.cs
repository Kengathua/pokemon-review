using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        bool PokemonExists(int pokemonId);
        Pokemon GetPokemon(int pokemonId);
    }
}