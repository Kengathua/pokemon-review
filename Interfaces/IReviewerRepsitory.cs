using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        bool ReviewerExists(int reviewerId);
        Reviewer GetReviewer(int reviewerId);
    }
}