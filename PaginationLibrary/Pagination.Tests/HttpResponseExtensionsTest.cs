using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Pagination.Extensions;
using Xunit;

namespace Pagination.Tests
{
    [Trait("Category", "Pagination")]
    public class HttpResponseExtensionsTest
    {
        private const string PageKey = "page";
        private const string PerPageKey = "per_page";

        [Fact(DisplayName = "AddPaginationHeaders should add pagination headers to the Response")]
        public void AddPaginationHeadersShouldAddPaginationHeadersToResponse()
        {
            //Initialize
            var context = new DefaultHttpContext();
            var unused = new DefaultHttpRequest(context)
            {
                Scheme = "http",
                Host = new HostString("localhost", 5000),
                Path = new PathString("/v1/employees"),
                QueryString = new QueryString($"?{PageKey}=2&{PerPageKey}=3&active=true")
            };

            //Setup
            var response = new DefaultHttpResponse(context);
            var paginationInfo = new PaginationInfo(new PaginationParams {Page = 2, PerPage = 3, Count = 10});

            //Invoke
            response.AddPaginationHeaders(paginationInfo);

            //Assert
            var expectedLink = $"<http://localhost:5000/v1/employees?active=true&{PageKey}=1&{PerPageKey}=3>; " +
                               $"rel=\"first\",<http://localhost:5000/v1/employees?active=true&{PageKey}=1&{PerPageKey}=3>; " +
                               $"rel=\"prev\",<http://localhost:5000/v1/employees?active=true&{PageKey}=3&{PerPageKey}=3>; " +
                               $"rel=\"next\",<http://localhost:5000/v1/employees?active=true&{PageKey}=4&{PerPageKey}=3>; " +
                               "rel=\"last\"";

            Assert.Equal(expectedLink, response.Headers["Link"]);
            Assert.Equal("2", response.Headers["X-Page"]);
            Assert.Equal("3", response.Headers["X-Per-Page"]);
            Assert.Equal("10", response.Headers["X-Total-Count"]);
            Assert.Equal("4", response.Headers["X-Total-Pages"]);
        }
    }
}