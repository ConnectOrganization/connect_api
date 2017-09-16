using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public interface IValidator<U>
    {
        List<ValidationResult> GetValidations();

		void Validate(U model);
    }
}