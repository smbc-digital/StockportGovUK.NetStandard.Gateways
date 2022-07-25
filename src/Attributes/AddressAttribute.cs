using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Models.Fostering;

namespace StockportGovUK.NetStandard.Gateways.Attributes
{
    public class AddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var addressModel = (Address)value;

            if (!string.IsNullOrEmpty(addressModel.SelectedAddress) && !string.IsNullOrEmpty(addressModel.Postcode) &&
                !string.IsNullOrEmpty(addressModel.PlaceRef))
            {
                return ValidationResult.Success;
            }

            if (!string.IsNullOrEmpty(addressModel.AddressLine1) && !string.IsNullOrEmpty(addressModel.Town) &&
                !string.IsNullOrEmpty(addressModel.Postcode))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Address is required");
        }
    }
}
