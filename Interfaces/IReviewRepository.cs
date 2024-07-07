using PokemonWebAPI.Models;

namespace PokemonWebAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        bool ReviewExists(int reviewId);
        Review GetReview(int reviewId);
    }
}