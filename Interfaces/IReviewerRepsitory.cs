using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
    }
}