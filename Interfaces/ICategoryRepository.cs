using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        bool CategoryExists(int categoryId);
        Category GetCategory(int categoryId);
    }
}