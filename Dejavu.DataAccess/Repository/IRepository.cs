using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dejavu.DataAccess.Repository
{
  public  interface IRepository<T> where T : class
  {
      T GetSingle(Object id);
      void Delete(Object id);
      void Delete(T t);
      IQueryable<T> GetAll();
      IQueryable<T> Find(Expression<Func<T, bool>> predicate);
      void Insert(T t);
      void Update(T t);
  }
}
