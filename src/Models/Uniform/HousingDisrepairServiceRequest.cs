using StockportGovUK.NetStandard.Gateways.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class HousingDisrepairServiceRequest
    {
        public string Description { get; set; }
        public string CrmReference { get; set; }
        public Address Property { get; set; }
        public Customer Customer { get; set; }
    }
}
