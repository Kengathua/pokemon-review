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
    
        public bool CategoryExists(int categoryId){
            return _context.Categories.Any(c => c.Id == categoryId);
        }
    
        public Category GetCategory(int categoryId){
            return _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault()
                    ?? throw new KeyNotFoundException($"Category with ID {categoryId} not found.");
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(pc => pc.CategoryId == categoryId).Select(pc => pc.Pokemon).ToList();
        }
    
        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }
    
        public bool Save(){
            return _context.SaveChanges()> 0? true: false;
        }
    }
}