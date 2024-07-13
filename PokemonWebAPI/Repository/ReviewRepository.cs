using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Review> GetReviews(){
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public bool ReviewExists(int reviewId){
            return _context.Reviews.Any(o => o.Id == reviewId);
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.SingleOrDefault(o => o.Id == reviewId) 
                   ?? throw new KeyNotFoundException($"Review with ID {reviewId} not found.");
        }

        public ICollection<Review> GetReviewsByPokemon(int pokeId){
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }
    }
}