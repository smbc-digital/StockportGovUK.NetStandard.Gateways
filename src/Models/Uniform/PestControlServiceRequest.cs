using StockportGovUK.NetStandard.Gateways.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class PestControlServiceRequest
    {
        public Payment Payment { get; set; }
        public string PestTypeCode { get; set; }
        public string PestLocationInformation { get; set; }
        public string siteLocationDescription { get; set; }
        public string Description { get; set; }
        public string CrmReference { get; set; }
        public Address Property { get; set; }
        public Customer Customer { get; set; }
    }
}