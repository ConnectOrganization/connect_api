using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ValidationResult> ValidationResults { get; }

        public ValidationException(List<ValidationResult> validations)
        {
            ValidationResults = validations;
        }
    }
}