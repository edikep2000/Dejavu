using Dejavu.DataAccess.Repository;
using Dejavu.Models;

namespace Dejavu.DataAccess.Service
{
    public class ProgramRatingsService
    {
        private readonly IRepository<ProgramRatings> _ratingsRepository;

        public ProgramRatingsService(IRepository<ProgramRatings> ratingsRepository)
        {
            _ratingsRepository = ratingsRepository;
        }
    }
}