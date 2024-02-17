using ElmTask.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTask.Common.Extentions
{
    public static class IEnumerableExtensions
    {

        public static QueryResult<T> ToQueryResult<T>(this IEnumerable<T> dbQuery, int pageNumber = 1, int pageSize = 10, bool isCountOnly = false, string sort = "", bool descending = true) where T : class
        {
            if (dbQuery == null)
                throw new ArgumentNullException("dbQuery");
            int count = dbQuery.Count();


            dbQuery = dbQuery.Page(pageNumber, pageSize);

            var data = isCountOnly ? null : dbQuery.ToList();
            pageNumber = (int)Math.Ceiling((decimal)count / (decimal)pageSize);

            return new QueryResult<T>(data, count, pageNumber, pageSize);
        }

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1)
                pageNumber = 1;
            if (pageSize <= 0)
                return source;
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }


    }
}
