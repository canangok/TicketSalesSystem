using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSalesSystem.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors;
        public ValidationException(ValidationResult validationResult) 
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }

        }
    }
}
