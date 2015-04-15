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
    }
}