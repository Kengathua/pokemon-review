using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }
    
        public bool OwnerExists(int ownerId){
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.SingleOrDefault(o => o.Id == id) 
                   ?? throw new KeyNotFoundException($"Owner with ID {id} not found.");
        }
    
        public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(po => po.OwnerId == ownerId).Select(po => po.Pokemon).ToList();
        }
    }
}
