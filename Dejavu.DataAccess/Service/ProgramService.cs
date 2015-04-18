using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dejavu.DataAccess.Repository;
using Dejavu.Models;

namespace Dejavu.DataAccess.Service
{
   public class ProgramService
   {
       private readonly IRepository<Program> _programRepository;

       public ProgramService(IRepository<Program> programRepository)
       {
           _programRepository = programRepository;
       }

       public Task Insert(Program m)
       {
           _programRepository.Insert(m);
           return Task.FromResult<Object>(null);
       }

       public Task Delete(int id)
       {
            _programRepository.Delete(id);
           return Task.FromResult<Object>(null);
       }

       public Task Delete(Program m)
       {
           _programRepository.Delete(m);
           return Task.FromResult<Object>(null);
       }

       public Task<Program> GetSingle(int id)
       {
           var m = _programRepository.GetSingle(id);
           return Task.FromResult(m);
       }

       public Task<IQueryable<Program>> GetAll()
       {
           var m = _programRepository.GetAll();
           return Task.FromResult(m);
       }
   }
}