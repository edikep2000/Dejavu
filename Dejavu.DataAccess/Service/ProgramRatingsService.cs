using System.Linq;
using System.Threading.Tasks;
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

        public Task Insert(ProgramRatings rating)
        {
            _ratingsRepository.Insert(rating);
            return Task.FromResult<object>(null);
        }

        public Task Delete(ProgramRatings rating)
        {
            _ratingsRepository.Delete(rating);
            return Task.FromResult<object>(null);
        }

        public Task<IQueryable<ProgramRatings>> GetAll()
        {
            var item = _ratingsRepository.GetAll();
            return Task.FromResult(item);
        }

        public Task<IQueryable<ProgramRatings>> GetForProgram(int programId)
        {
            var model = _ratingsRepository.Find(i => i.ProgramId == programId);
            return Task.FromResult(model);
        }
    }
}