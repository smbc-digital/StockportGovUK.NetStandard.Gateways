using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockportGovUK.NetStandard.Gateways.Models.Verint.VerintOnlineForm
{
    public class VerintOnlineFormRequest
    {
        [Required]
        public Case VerintCase { get; set; }

        [Required]
        public string FormName { get; set; }

        [Required]
        public IDictionary<string, string> FormData { get; set; }
    }
}