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
    }
}