using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
     public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, IValidationContext entity)
        {

            ValidationResult result = validator.Validate(entity);

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
