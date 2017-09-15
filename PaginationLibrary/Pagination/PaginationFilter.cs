using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Pagination.Extensions;

namespace Pagination
{
    public class PaginationFilter : ActionFilterAttribute
    {
        private PaginationParams _paginationParams;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Values.OfType<PaginationParams>().Any())
            {
                _paginationParams = context.ActionArguments.Values.OfType<PaginationParams>().First();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (_paginationParams != null)
            {
                var paginationInfo = new PaginationInfo(_paginationParams);
                context.HttpContext.Response.AddPaginationHeaders(paginationInfo);
            }
        }
    }
}