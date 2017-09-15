using System;

namespace Pagination
{
    public class PaginationInfo
    {
        public PaginationInfo(PaginationParams paginationParams)
        {
            Page = paginationParams.Page;
            PerPage = paginationParams.PerPage;
            TotalCount = paginationParams.Count;
        }

        public int Page { get; }

        public int PerPage { get; }

        public int TotalCount { get; }

        public int TotalPages => (int) Math.Ceiling((decimal) TotalCount / PerPage);
    }
}