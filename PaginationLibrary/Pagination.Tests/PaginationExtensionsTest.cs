using System.Linq;
using Pagination.Extensions;
using Pagination.Tests.Fixtures;
using Xunit;

namespace Pagination.Tests
{
    [Trait("Category", "Pagination")]
    public class PaginationExtensionsTest : IClassFixture<TestFixture>
    {
        public PaginationExtensionsTest(TestFixture fixture)
        {
            _testObjects = fixture.TestObjects;
        }

        private static IQueryable<TestObject> _testObjects;

        [Fact(DisplayName = "ToPaginatedList returns a PaginatedList containing a collection and PaginationInfo")]
        public void ToPaginatedListShouldReturnPaginatedList()
        {
            var paginationParams = new PaginationParams
            {
                Page = 1,
                PerPage = 2
            };
            var result = _testObjects.GetList(paginationParams).ToList();

            Assert.Equal(1, result[0].TestId);
            Assert.Equal("Tom", result[0].TestName);
            Assert.Equal(2, result[1].TestId);
            Assert.Equal("Sam", result[1].TestName);
            Assert.Equal(5, paginationParams.Count);
        }

        [Fact(DisplayName = "ToPaginatedList with invalid page sets to default page 1")]
        public void ToPaginatedListWithInvalidPageShouldSetPageToOne()
        {
            var paginationParams = new PaginationParams
            {
                Page = -1,
                PerPage = 2
            };

            _testObjects.GetList(paginationParams);
            var paginationInfo = new PaginationInfo(paginationParams);

            Assert.Equal(1, paginationInfo.Page);
            Assert.Equal(5, paginationInfo.TotalCount);
            Assert.Equal(3, paginationInfo.TotalPages);
        }

        [Fact(DisplayName = "ToPaginatedList with invalid perpage sets to default perpage 25")]
        public void ToPaginatedListWithInvalidPerPageShouldSetPerPageToTwentyFive()
        {
            var paginationParams = new PaginationParams
            {
                Page = 1,
                PerPage = -2
            };

            _testObjects.GetList(paginationParams);
            var paginationInfo = new PaginationInfo(paginationParams);

            Assert.Equal(25, paginationInfo.PerPage);
            Assert.Equal(5, paginationInfo.TotalCount);
            Assert.Equal(1, paginationInfo.TotalPages);
        }
    }
}