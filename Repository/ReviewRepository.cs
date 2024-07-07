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
    }
}