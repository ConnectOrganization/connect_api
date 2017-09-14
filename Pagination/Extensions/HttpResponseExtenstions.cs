using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;

namespace Pagination.Extensions
{
    public static class HttpResponseExtenstions
    {
        public static void AddPaginationHeaders(this HttpResponse response, PaginationInfo paginationInfo)
        {
            response.Headers.Add("Link",
                new PaginationLinkHeaderBuilder(response.HttpContext.Request.GetUri(), paginationInfo).Build());
            response.Headers.Add("X-Page", paginationInfo.Page.ToString());
            response.Headers.Add("X-Per-Page", paginationInfo.PerPage.ToString());
            response.Headers.Add("X-Total-Count", paginationInfo.TotalCount.ToString());
            response.Headers.Add("X-Total-Pages", paginationInfo.TotalPages.ToString());
        }
    }
}