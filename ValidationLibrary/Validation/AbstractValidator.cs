using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Validation
{
    public abstract class AbstractValidator<T, U> : IValidator<U> where T : DbContext
    {
        protected readonly T _context;

        protected List<ValidationResult> ValidationResults { get; set; } = new List<ValidationResult>();

        protected AbstractValidator()
        {
        }

        protected AbstractValidator(T context)
        {
            _context = context;
        }

        public virtual void Validate(U model)
        {
            // Do nothing
        }

        public List<ValidationResult> GetValidations()
        {
            return ValidationResults;
        }
    }
}