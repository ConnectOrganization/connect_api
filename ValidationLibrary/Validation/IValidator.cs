using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public interface IValidator<in TU>
    {
        List<ValidationResult> GetValidations();

        void Validate(TU model);
    }
}