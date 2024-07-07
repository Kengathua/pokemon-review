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
    }
}