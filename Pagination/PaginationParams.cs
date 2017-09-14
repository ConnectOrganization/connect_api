using Newtonsoft.Json;

namespace Pagination
{
    public class PaginationParams
    {
        [JsonIgnore]
        public int Count { get; set; }

        private int _page;
        private int _perPage;

        public PaginationParams()
        {
            _page = Page;
            _perPage = PerPage;
        }

        public int Page
        {
            get => _page <= 0 ? 1 : _page;
            set => _page = value;
        }

        public int PerPage
        {
            get => _perPage <= 0 ? 25 : _perPage;
            set => _perPage = value;
        }
    }
}