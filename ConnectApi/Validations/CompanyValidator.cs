using ConnectApi.Models;
using Validation;
using System.ComponentModel.DataAnnotations;

namespace ConnectApi.Validations
{
    public class CompanyValidator : AbstractValidator<ConnectDbContext, Company>
    {
        public CompanyValidator(ConnectDbContext context) : base(context)
        {
        }

        public override void Validate(Company company)
        {
            var validationContext = new ValidationContext(company.Address, null, null);
            Validator.TryValidateObject(company.Address, validationContext, ValidationResults, true);
        }
    }
}