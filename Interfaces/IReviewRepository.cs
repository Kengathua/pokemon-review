using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
    }
}