using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint.Update
{
    public class IntegrationFormFieldsUpdateModel
    {
        [Required]
        public string CaseReference { get; set; }

        [Required]
        public string IntegrationFormName { get; set; }

        [Required, MinLength(1, ErrorMessage = "At least one item is required")]
        public List<IntegrationFormField> IntegrationFormFields { get; set; }
    }
}