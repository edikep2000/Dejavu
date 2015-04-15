using System;
using System.Linq;
using System.Linq.Expressions;
using Telerik.OpenAccess;

namespace Dejavu.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly OpenAccessContext _context;

        public Repository(OpenAccessContext context)
        {
            _context = context;
        }

        public T GetSingle(Object id)
        {
            var objectKey = new ObjectKey(typeof (T).Name, id);
            var entity = _context.GetObjectByKey<T>(objectKey);
            return entity;
        }

        public void Delete(Object id)
        {
            var item = GetSingle(id);
            Delete(item);
        }

        public void Delete(T t)
        {
            _context.Delete(t);
        }

        public IQueryable<T> GetAll()
        {
            return _context.GetAll<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.GetAll<T>().Where(predicate);
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void Update(T t)
        {
            _context.AttachCopy(t);
        }
    }
}