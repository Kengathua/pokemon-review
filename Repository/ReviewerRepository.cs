using PokemonWebAPI.Data;
using PokemonWebAPI.Interfaces;
using PokemonWebAPI.Models;

namespace PokemonWebAPI.Repository
{
    public class ReviewerRepository: IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }
    
        public ICollection<Reviewer> GetReviewers(){
            return _context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        public bool ReviewerExists(int reviewerId){
            return _context.Reviewers.Any(o => o.Id == reviewerId);
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _context.Reviewers.SingleOrDefault(o => o.Id == reviewerId) 
                   ?? throw new KeyNotFoundException($"Reviewer with ID {reviewerId} not found.");
        }
    
        public ICollection<Review> GetReviewsByReviewer(int reviewerId){
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }
    }
}