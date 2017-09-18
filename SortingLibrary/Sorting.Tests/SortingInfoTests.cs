using System;
using Xunit;

namespace Sorting.Tests
{
    [Trait("Category", "Sorting")]
    public class SortingInfoTests
    {
        [Fact(DisplayName = "Adding item with param should add to list")]
        public void AddingItemWithParamShouldAddToList()
        {
            //  Arrange
            var sortingInfo = new SortingInfo();

            //  Actual
            sortingInfo.Add("Param1", Sorting.Asc);
            sortingInfo.Add("Param2", Sorting.Dsc);

            //  Assertions
            Assert.Equal(2, sortingInfo.Size());
        }

        [Fact(DisplayName = "Adding item with object should add to list")]
        public void AddingItemWithObjectShouldAddToList()
        {
            //  Arrange
            var sortingInfo = new SortingInfo();

            //  Actual
            sortingInfo.Add(new SortingElement("Param1", Sorting.Asc));
            sortingInfo.Add(new SortingElement("Param2", Sorting.Dsc));

            //  Assertions
            Assert.Equal(2, sortingInfo.Size());
        }

        [Fact(DisplayName = "Adding item with param should add to list at Index")]
        public void AddingItemWithParamShouldAddToListAtIndex()
        {
            //  Arrange
            var sortingInfo = new SortingInfo();

            //  Actual
            sortingInfo.Add(new SortingElement("Param1", Sorting.Asc));
            sortingInfo.Add(new SortingElement("Param2", Sorting.Dsc));
            sortingInfo.InsertAtIndex(0, "Param3", Sorting.Asc);
            sortingInfo.InsertAtIndex(0, "Param4", Sorting.Dsc);
            var sortingItems = sortingInfo.Iterator();

            //  Assertions
            Assert.Equal(4, sortingInfo.Size());
            Assert.Equal("Param4", sortingItems[0].GetOrderBy());
            Assert.Equal("Param3", sortingItems[1].GetOrderBy());
        }

        [Fact(DisplayName = "Parse sorting Header with valid string")]
        public void ParseSortingHeaderWithValidString()
        {
            //  Actual
            var sortingInfo = SortingInfo.Parse("anand_asc;manju_dsc");
            var sortingItems = sortingInfo.Iterator();

            //  Assertions
            Assert.Equal(2, sortingInfo.Size());
            Assert.Equal("anand", sortingItems[0].GetOrderBy());
            Assert.Equal("manju", sortingItems[1].GetOrderBy());
        }

        [Fact(DisplayName = "Parse sorting Header with invalid string")]
        public void ParseSortingHeaderWithInValidString()
        {
            //  Actual
            var error = Assert.Throws(typeof(InvalidOperationException), () => SortingInfo.Parse("anand_sort"));

            //  Assertions
            Assert.Equal("Sorting Header mal formed for sorting", error.Message);
        }

        [Fact(DisplayName = "Result null on parsing empty header")]
        public void ResultNullOnParsingEmptyHeader()
        {
            //  Actual
            var sortingInfo = SortingInfo.Parse(null);

            //  Assertions
            Assert.Null(sortingInfo);
        }
    }
}