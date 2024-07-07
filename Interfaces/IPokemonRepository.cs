using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
    }
}