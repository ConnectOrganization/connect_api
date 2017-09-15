using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagination.Tests.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IQueryable<TestObject> TestObjects;

        public TestFixture()
        {
            Setup();
        }

        public void Dispose()
        {
            TestObjects = null;
        }

        private void Setup()
        {
            IList<TestObject> testObjects = new List<TestObject>();

            testObjects.Add(new TestObject
            {
                TestId = 1,
                TestName = "Tom"
            });
            testObjects.Add(new TestObject
            {
                TestId = 2,
                TestName = "Sam"
            });
            testObjects.Add(new TestObject
            {
                TestId = 3,
                TestName = "Ram"
            });
            testObjects.Add(new TestObject
            {
                TestId = 4,
                TestName = "Pam"
            });
            testObjects.Add(new TestObject
            {
                TestId = 5,
                TestName = "Dam"
            });

            TestObjects = testObjects.AsQueryable();
        }
    }
}