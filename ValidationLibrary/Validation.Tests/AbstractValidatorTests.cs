using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Validation.Tests
{
    [Trait("Category", "Validation")]
    public class AbstractValidatorTests
    {
        [Fact(DisplayName = "Constructor should success")]
        public void Constructor()
        {
            // Actual
            var validator = new AbstractValidatorTest();

            // Assertions
            Assert.NotNull(validator);
            Assert.Equal(0, validator.GetValidations().Count);
            Assert.Null(validator.GetContext());
        }

        [Fact(DisplayName = "Constructor with arguments should success")]
        public void ConstructorWithArgumentsShouldSuccess()
        {
            // Arrange
            var dbContext = new DbContextTest();

            // Actual
            var validator = new AbstractValidatorTest(dbContext);

            // Assertions
            Assert.NotNull(validator);
            Assert.Equal(0, validator.GetValidations().Count);
            Assert.NotNull(validator.GetContext());
            Assert.Same(dbContext, validator.GetContext());
        }
    }

    public class DbContextTest : DbContext
    {
    }

    public class AbstractValidatorTest : AbstractValidator<DbContext, ModelClassTest>
    {
        public AbstractValidatorTest()
        {
        }

        public AbstractValidatorTest(DbContext context) : base(context)
        {
        }

        public DbContext GetContext()
        {
            return Context;
        }
    }

    public class ModelClassTest
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}