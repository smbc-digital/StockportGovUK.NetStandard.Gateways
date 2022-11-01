using StockportGovUK.NetStandard.Gateways.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class TaxiLicensingServiceRequest
    {
        public string ComplaintType { get; set; }
        public string Description { get; set; }
        public Address Property { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}