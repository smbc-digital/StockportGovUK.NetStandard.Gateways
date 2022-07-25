using StockportGovUK.NetStandard.Gateways.Models.Addresses;
using StockportGovUK.NetStandard.Gateways.Models.ContactDetails;

namespace StockportGovUk.NetStandard.Gateways.Models.ParkingEnforcement
{
    public class ParkingEnforcementRequest
    {
        public bool IsARestrictedArea { get; set; }

        public ContactDetails ContactDetails { get; set; }

        public Street Street { get; set; }

        public string FurtherDetails { get; set; }
    }
}