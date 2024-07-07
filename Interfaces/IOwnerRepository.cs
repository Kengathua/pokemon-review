using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        bool OwnerExists(int ownerId);
        Owner GetOwner(int ownerId);
        ICollection<Pokemon> GetPokemonsByOwner(int ownerId);
    }
}