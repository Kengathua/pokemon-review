using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
    }
}