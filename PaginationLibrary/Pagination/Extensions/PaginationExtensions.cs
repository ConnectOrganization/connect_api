using System.Linq;

namespace Pagination.Extensions
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> GetList<T>(this IQueryable<T> query, PaginationParams paginationParams)
        {
            paginationParams.Count = query.Count();
            return query.Skip((paginationParams.Page - 1) * paginationParams.PerPage)
                .Take(paginationParams.PerPage);
        }
    }
}