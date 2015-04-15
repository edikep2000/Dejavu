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
   }
}
