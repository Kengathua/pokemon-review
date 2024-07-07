using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Category> GetCategories(){
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }
    }
}