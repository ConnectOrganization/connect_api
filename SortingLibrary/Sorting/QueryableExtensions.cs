using System.Linq;
using System.Reflection;

namespace Sorting
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> IncludeOrderBy<T>(this IQueryable<T> query, SortingInfo sortingInfo)
        {
            IOrderedQueryable<T> orderedQueryable = null;
            foreach (var sortingElement in sortingInfo.Iterator())
            {
                var orderBy = sortingElement.GetOrderBy();

                var param = orderBy;
                var propertyInfo = typeof(T).GetProperty(param);
                if (orderedQueryable == null)
                {
                    orderedQueryable = sortingElement.IsAsc()
                        ? query.OrderBy(x => propertyInfo.GetValue(x, null))
                        : query.OrderByDescending(x => propertyInfo.GetValue(x, null));
                }
                else
                {
                    orderedQueryable = sortingElement.IsAsc()
                        ? orderedQueryable.ThenBy(x => propertyInfo.GetValue(x, null))
                        : orderedQueryable.ThenByDescending(x => propertyInfo.GetValue(x, null));
                }
            }
            return orderedQueryable;
        }
    }
}