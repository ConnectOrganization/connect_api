using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Validation
{
    public abstract class AbstractValidator<T, TU> : IValidator<TU> where T : DbContext
    {
        protected readonly T Context;

        protected List<ValidationResult> ValidationResults { get; set; } = new List<ValidationResult>();

        protected AbstractValidator()
        {
        }

        protected AbstractValidator(T context)
        {
            Context = context;
        }

        public virtual void Validate(TU model)
        {
            // Do nothing
        }

        public List<ValidationResult> GetValidations()
        {
            return ValidationResults;
        }
    }
}