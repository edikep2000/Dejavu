using System.Linq;
using System.Threading.Tasks;
using Dejavu.DataAccess.Repository;
using Dejavu.Models;

namespace Dejavu.DataAccess.Service
{
    public class ProgramTestimoniesService
    {
        private readonly IRepository<ProgramTestimonies> _repository;

        public ProgramTestimoniesService(IRepository<ProgramTestimonies> repository)
        {
            _repository = repository;
        }

        public Task<IQueryable<ProgramTestimonies>> GetAll()
        {
            return Task.FromResult(_repository.GetAll());
        }

        public Task<IQueryable<ProgramTestimonies>> GetAll(int programId)
        {
            return Task.FromResult(_repository.Find(i => i.ProgramId == programId));
        }

        public Task Delete(int id)
        {
            _repository.Delete(id);
          return  Task.FromResult<object>(null);
        }

        public Task Insert(ProgramTestimonies testimony)
        {
            _repository.Insert(testimony);
            return Task.FromResult<object>(null);
        }

        public Task<ProgramTestimonies> GetSingle(int id)
        {
            var item = _repository.GetSingle(id);
            return Task.FromResult(item);
        }
    }
}