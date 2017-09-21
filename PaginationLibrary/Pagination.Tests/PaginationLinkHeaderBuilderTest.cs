using System;
using Xunit;

namespace Pagination.Tests
{
    [Trait("Category", "Pagination")]
    public class PaginationLinkHeaderBuilderTest
    {
        private const string PageKey = "page";
        private const string PerPageKey = "per_page";
        private const string BaseUri = "http://localhost:5000/v1/employees";
        private readonly string _defaultPaginationQueryString = $"{PageKey}=1&{PerPageKey}=25";

        [Fact(DisplayName = "Build links with QueryString should return all links (First,Previous,Next,Last)")]
        public void BuildWithQueryStringShouldReturnAllLinks()
        {
            //Setup
            var paginationInfo = new PaginationInfo(new PaginationParams {Page = 2, PerPage = 3, Count = 10});
            var queryString = $"?{PageKey}=2&{PerPageKey}=3&active=true";

            //Invoke
            var actualLink = BuildActualLink(queryString, paginationInfo);

            //Assert
            var expectedLink = $"<{BaseUri}?active=true&{PageKey}=1&{PerPageKey}=3>; " +
                               $"rel=\"first\",<{BaseUri}?active=true&{PageKey}=1&{PerPageKey}=3>; " +
                               $"rel=\"prev\",<{BaseUri}?active=true&{PageKey}=3&{PerPageKey}=3>; " +
                               $"rel=\"next\",<{BaseUri}?active=true&{PageKey}=4&{PerPageKey}=3>; " +
                               "rel=\"last\"";

            Assert.Equal(expectedLink, actualLink);
        }

        [Fact(DisplayName = "Build without PerPage should return link with default PerPage")]
        public void BuildWithoutPerPageShouldReturnLinkWithDefaultPerPage()
        {
            //Setup
            var paginationInfo = new PaginationInfo(new PaginationParams {Page = 1, Count = 10});
            var queryString = $"?{PageKey}=1";

            //Invoke
            var actualLink = BuildActualLink(queryString, paginationInfo);

            //Assert
            var expectedLink = $"<{BaseUri}?{_defaultPaginationQueryString}>; " +
                               $"rel=\"first\",<{BaseUri}?{_defaultPaginationQueryString}>; rel=\"last\"";

            Assert.Equal(expectedLink, actualLink);
        }

        [Fact(DisplayName = "Build without QueryString should return default pagination links")]
        public void BuildWithoutQueryStringShouldReturnPaginationLinks()
        {
            //Setup
            var paginationInfo = new PaginationInfo(new PaginationParams() {Count = 10});

            //Invoke
            var actualLink = BuildActualLink("", paginationInfo);

            //Assert
            var expectedLink = $"<{BaseUri}?{_defaultPaginationQueryString}>; " +
                               $"rel=\"first\",<{BaseUri}?{_defaultPaginationQueryString}>; rel=\"last\"";

            Assert.Equal(expectedLink, actualLink);
        }

        [Theory(DisplayName = "Build with invalid pagination values should return link with default values"),
         InlineData(-2, -3),
         InlineData(0, 0)]
        public void BuildWithInvalidPaginationValuesShouldReturnLinkWithDefaultValues(int page, int perPage)
        {
            //Setup
            var paginationInfo = new PaginationInfo(new PaginationParams {Page = page, PerPage = perPage, Count = 10});

            //Invoke
            var actualLink = BuildActualLink("", paginationInfo);

            //Assert
            var expectedLink = $"<{BaseUri}?{_defaultPaginationQueryString}>; " +
                               $"rel=\"first\",<{BaseUri}?{_defaultPaginationQueryString}>; rel=\"last\"";

            Assert.Equal(expectedLink, actualLink);
        }

        private static string BuildActualLink(string queryString, PaginationInfo paginationInfo)
        {
            //Initialize
            var uri = new Uri($"{BaseUri}{queryString}");
            var paginationLinkHeaderBuilder = new PaginationLinkHeaderBuilder(uri, paginationInfo);

            //Invoke
            var actualLink = paginationLinkHeaderBuilder.Build();
            return actualLink;
        }
    }
}