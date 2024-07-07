using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
    }
}