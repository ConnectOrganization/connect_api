using System.Collections.Generic;

namespace Pagination
{
    public class PaginatedList<T>
    {
        public IList<T> List { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}