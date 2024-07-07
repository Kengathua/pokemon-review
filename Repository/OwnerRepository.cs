using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class OwnerRepository: IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Owner> GetOwners(){
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }
    }
}