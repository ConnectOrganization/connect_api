using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

namespace Validation
{
    public class ValidationDbContext : DbContext
    {
        public ValidationDbContext(DbContextOptions options) : base(options)
        {
        }

        public T Update<T>(T entity, IValidator<T> validator) where T : class, new()
        {
            Validate(entity, validator);
            return Update(entity).Entity;
        }

        public  T Add<T>(T entity, IValidator<T> validator) where T : class, new()
        {
            Validate(entity, validator);
            return base.Add(entity).Entity;
        }

        private void Validate<T>(T entity, IValidator<T> validtor)
        {
            var validationContext = new ValidationContext(entity, null, null);
            var validationResults = new List<ValidationResult>();

            if (validtor != null)
            {
                // Call custom validation
                validtor.Validate(entity);
                validationResults = validtor.GetValidations();
            }

            // Call data annotation validations
            Validator.TryValidateObject(entity, validationContext, validationResults, true);

            if (validationResults.Any())
            {
                throw new Exceptions.ValidationException(validationResults);
            }
        }
    }
}