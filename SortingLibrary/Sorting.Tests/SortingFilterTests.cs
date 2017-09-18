using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Xunit;

namespace Sorting.Tests
{
    [Trait("Category", "Sorting")]
    public class SortingFilterTests
    {
        private readonly SortingFilter _sortingFilter;
        private readonly ActionContext _actionContext;
        private ActionExecutingContext _actionExecutingContext;

        public SortingFilterTests()
        {
            _sortingFilter = new SortingFilter();
            _actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext
                {
                    Request =
                    {
                        QueryString = new QueryString("?sort=prop1_asc;prop2_dsc")
                    },
                },
                RouteData = new RouteData(),
                ActionDescriptor = new ControllerActionDescriptor()
            };
        }

        [Fact(DisplayName = "Adding item with param should add to list")]
        public void AddingItemWithParamShouldAddToList()
        {
            // Arrange
            var sortingInfo = new SortingInfo();
            var arguments = new Dictionary<string, object> {{"sort", sortingInfo}};
            _actionExecutingContext = new ActionExecutingContext(_actionContext, new List<IFilterMetadata>(),
                arguments, null);

            // Act
            _sortingFilter.OnActionExecuting(_actionExecutingContext);

            // Assert
            Assert.Null(_actionExecutingContext.Result);
            Assert.Equal(2, sortingInfo.Size());
            Assert.Collection(sortingInfo.Iterator(),
                element =>
                {
                    Assert.Equal("prop1", element.GetOrderBy());
                    Assert.True(element.IsAsc());
                },
                element =>
                {
                    Assert.Equal("prop2", element.GetOrderBy());
                    Assert.False(element.IsAsc());
                }
            );
        }
    }
}