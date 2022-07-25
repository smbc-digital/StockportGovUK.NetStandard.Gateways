using System.ComponentModel.DataAnnotations;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace StockportGovUK.NetStandard.Gateways.Models.Addresses
{
    public class AddressSearch
    {
        [Required]
        public EAddressProvider AddressProvider { get; set; }

        [Required]
        [MinLength(3)]
        public string SearchTerm { get; set; }
    }
}
