using StockportGovUK.NetStandard.Gateways.Models.Verint;
using System;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class NoiseNuisanceServiceRequest
    {
        public string NoiseNuisanceCode { get; set; }
        public string NoiseNuisanceType { get; set; }
        public string Description { get; set; }
        public string CrmReference { get; set; }
        public string TradingAs { get; set; }
        public Address Property { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateItHappened { get; set; }
        public string TimeItHappened { get; set; }
    }
}
