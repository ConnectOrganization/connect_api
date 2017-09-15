using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sorting.Tests
{
    [Trait("Category", "Sorting")]
    public class QueryableExtensionsTests
    {
        [Fact(DisplayName = "Include orderby should return valid Ordered Query")]
        public void IncludeOrderByShouldReturnValidOrderedQuery()
        {
            // Arrange
            var sortingInfo = new SortingInfo();
            sortingInfo.Add(new SortingElement("Param1", Sorting.Asc));
            sortingInfo.Add(new SortingElement("Param5", Sorting.Dsc));

            var items = new List<ItemsTest>{
                new ItemsTest{
                    Param1="A",
                    Param2="B",
                    Param3="C",
                    Param4="D",
                    Param5="E"
                },
                new ItemsTest{
                    Param1="A",
                    Param2="C",
                    Param3="D",
                    Param4="E",
                    Param5="F"
                },
                new ItemsTest{
                    Param1="B",
                    Param2="C",
                    Param3="D",
                    Param4="E",
                    Param5="F"
                },
                new ItemsTest{
                    Param1="B",
                    Param2="C",
                    Param3="D",
                    Param4="E",
                    Param5="F"
				},
				new ItemsTest{
					Param1="c",
					Param2="D",
					Param3="E",
					Param4="F",
					Param5="G"
				},
				new ItemsTest{
					Param1="C",
					Param2="D",
					Param3="E",
					Param4="F",
					Param5="G"
				}
            };

            var query = items.AsQueryable();

            // Actual
            var result = query.IncludeOrderBy(sortingInfo).ToList();

			// Assertions
			Assert.Equal("F", result[0].Param5);
        }

		[Fact(DisplayName = "Include orderby should return valid Ordered Dsc Query")]
		public void IncludeOrderByShouldReturnValidOrderedDscQuery()
		{
			// Arrange
			var sortingInfo = new SortingInfo();
			sortingInfo.Add(new SortingElement("Param1", Sorting.Dsc));
			sortingInfo.Add(new SortingElement("Param2", Sorting.Dsc));

			var items = new List<ItemsTest>{
				new ItemsTest{
					Param1="A",
					Param2="B",
					Param3="C",
					Param4="D",
					Param5="E"
				},
				new ItemsTest{
					Param1="A",
					Param2="D",
					Param3="E",
					Param4="F",
					Param5="G"
				},
				new ItemsTest{
					Param1="B",
					Param2="C",
					Param3="D",
					Param4="E",
					Param5="F"
				},
				new ItemsTest{
					Param1="B",
					Param2="D",
					Param3="E",
					Param4="F",
					Param5="G"
				},
				new ItemsTest{
					Param1="C",
					Param2="D",
					Param3="E",
					Param4="F",
					Param5="G"
				},
				new ItemsTest{
					Param1="C",
					Param2="E",
					Param3="F",
					Param4="G",
					Param5="H"
				}
			};

			var query = items.AsQueryable();

			// Actual
			var result = query.IncludeOrderBy(sortingInfo).ToList();

			// Assertions
			Assert.Equal("C", result[0].Param1);
            Assert.Equal("E", result[0].Param2);
			Assert.Equal("B", result[2].Param1);
			Assert.Equal("D", result[2].Param2);
			Assert.Equal("A", result[5].Param1);
			Assert.Equal("B", result[5].Param2);
		}
    }

    internal class ItemsTest
    {
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Param3 { get; set; }
        public string Param4 { get; set; }
        public string Param5 { get; set; }
    }
}
