using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace StockportGovUK.NetStandard.Gateways.Attributes
{
    public class RequiredIf : ValidationAttribute
    {
        private readonly string _expressionPropertyName;
        private readonly string _errorMessage;

        public RequiredIf(string expressionPropertyName, string errorMessage)
        {
            _expressionPropertyName = expressionPropertyName;
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type objectType = validationContext.ObjectInstance.GetType();
            IList<PropertyInfo> objectProperties = new List<PropertyInfo>(objectType.GetProperties());
            var expression = objectProperties.Single(_ => _.Name == _expressionPropertyName).GetValue(validationContext.ObjectInstance);

            if ((bool)expression)
            {
                if (value != null)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
