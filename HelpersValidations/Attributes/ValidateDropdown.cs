using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersValidations.Attributes
{
    public class ValidateDropdown : ValidationAttribute ,IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-validateDropdown", ErrorMessage);
        }

        public override bool IsValid(object value)
        {
            if ((string)value == "")
            {
                return false;
            }
            return true;
        }
    }
}
