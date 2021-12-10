using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper
{
    public static class ListHelper
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            //var random = new Random();
            //source = source.Select(sel => new { index = random.Next(0, source.Count()), value = sel }).OrderBy(orderBy => orderBy.index).Select(sel => sel.value);
            var r = new Random((int)DateTime.Now.Ticks);
            var shuffledList = source.Select(x => new { Number = r.Next(), Item = x }).OrderBy(x => x.Number).Select(x => x.Item);
            return shuffledList.ToList();
        }
        public static double CalculateAverage<T>(this IEnumerable<T> source, Func<T, double> selector)
        {
            if(source.Count() == 0)
            {
                return 0;
            }
            return source.Average(selector);
        }
        public static IQueryable<TEntity> SortByProperty<TEntity>(this IQueryable<TEntity> source, string sortProperty, bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(sortProperty);
            if(property != null)
            {
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);

                var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                   source.Expression, Expression.Quote(orderByExpression));

                return source.Provider.CreateQuery<TEntity>(resultExpression);
            }
            return source;
        }
    }
}
