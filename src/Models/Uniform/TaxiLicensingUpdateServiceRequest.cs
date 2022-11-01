
namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class TaxiLicensingUpdateRequest
    {
        public string Reference { get; set; }
        public string Description { get; set; }
        public Payment Payment { get; set; }
    }
}