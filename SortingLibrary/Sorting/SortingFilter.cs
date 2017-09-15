using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sorting
{
    public class SortingFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Values.OfType<SortingInfo>().Any())
            {
                var sortingInfo = context.ActionArguments.Values.OfType<SortingInfo>().First();
                if (context.HttpContext.Request.Query.ContainsKey("sort"))
                {
                    var items = SortingInfo.Parse(context.HttpContext.Request.Query["sort"]);
                    foreach (var item in items.Iterator())
                    {
                        sortingInfo.Add(item);
                    }
                }
            }
        }
    }
}