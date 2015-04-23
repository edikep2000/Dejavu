using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dejavu.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> list, int page, int pageSize)
        {
            return list.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
