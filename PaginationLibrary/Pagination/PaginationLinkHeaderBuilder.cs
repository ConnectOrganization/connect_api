using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;

namespace Pagination
{
    public class PaginationLinkHeaderBuilder
    {
        private const string PageKey = "page";
        private const string PerPageKey = "per_page";
        private readonly string _baseUri;
        private readonly PaginationInfo _paginationInfo;
        private readonly IDictionary<string, string> _query;

        public PaginationLinkHeaderBuilder(Uri uri, PaginationInfo paginationInfo)
        {
            _paginationInfo = paginationInfo;
            _baseUri = new UriBuilder(uri) {Query = null, Fragment = null}.Uri.ToString();
            _query = QueryHelpers.ParseQuery(uri.Query)
                .Where(
                    x =>
                        x.Key.ToLowerInvariant() != PerPageKey.ToLowerInvariant() &&
                        x.Key.ToLowerInvariant() != PageKey)
                .ToDictionary(x => x.Key, x => x.Value.ToString());
        }

        public string Build()
        {
            var link = new Dictionary<string, string> {["first"] = BuildLink(1)};


            if (_paginationInfo.Page > 1)
                link["prev"] = BuildLink(_paginationInfo.Page - 1);

            if (_paginationInfo.Page + 1 <= _paginationInfo.TotalPages)
                link["next"] = BuildLink(_paginationInfo.Page + 1);

            link["last"] = BuildLink(_paginationInfo.TotalPages);

            return string.Join(",", link.Select(x => $@"<{x.Value}>; rel=""{x.Key}"""));
        }

        private string BuildLink(int page)
        {
            _query[PageKey] = page.ToString();
            _query[PerPageKey] = _paginationInfo.PerPage.ToString();
            return QueryHelpers.AddQueryString(_baseUri, _query);
        }
    }
}