using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Application.Autores
{
    public class ValidateModel : IValidateModel
    {
        private List<ValidationResult> validationResults = new List<ValidationResult>();
       
        public bool TryValidateObject(object instance)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }
        public void AddError(string errorMessage)
        {
            validationResults.Add(new ValidationResult(errorMessage));
        }

        public void JoinValidate(ValidateModel validate)
        {
            validationResults.AddRange(validate.GetValidations());
        }

        public List<ValidationResult> GetValidations()
        {
            return validationResults.ToList();
        }

        public bool IsValid => !validationResults.Any();

        public List<string> ToListText()=> validationResults.Select(error => error.ErrorMessage).ToList();

    }
}
