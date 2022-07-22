﻿using StockportGovUK.NetStandard.Gateways.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.Models.Uniform
{
    public class BonfireNuisanceServiceRequest
    {
        public string BonfireNuisanceCode { get; set; }
        public string Description { get; set; }
        public string TradingAs { get; set; }
        public string CrmReference { get; set; }
        public Address Property { get; set; }
        public Customer Customer { get; set; }
    }
}