using System.Linq;
using System.Threading.Tasks;
using Dejavu.DataAccess.Repository;
using Dejavu.Models;

namespace Dejavu.DataAccess.Service
{
    public class ProgramReviewsService
    {
        private readonly IRepository<ProgramReviews> _reviewsRepository;

        public ProgramReviewsService(IRepository<ProgramReviews> reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }

        public Task<IQueryable<ProgramReviews>> GetAll()
        {
            return Task.FromResult(_reviewsRepository.GetAll());
        }

        public Task<IQueryable<ProgramReviews>> GetForProgram(int programId)
        {
            return Task.FromResult(_reviewsRepository.Find(I => I.ProgramId == programId));

        }

        public Task Delete(int id)
        {
           _reviewsRepository.Delete(id);
            return Task.FromResult<object>(null);
        }

        public Task Insert(ProgramReviews review)
        {
            _reviewsRepository.Insert(review);
            return Task.FromResult<object>(null);
        }
    }
}