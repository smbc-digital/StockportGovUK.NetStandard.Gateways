using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Street
{
    public class StreetSearch
    {
        [Required]
        public EStreetProvider StreetProvider { get; set; }

        [Required]
        [MinLength(3)]
        public string SearchTerm { get; set; }
    }
}
