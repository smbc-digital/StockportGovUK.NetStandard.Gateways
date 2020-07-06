using System;

namespace StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response
{
    public class GovUkMandateSetupResponse
    {
            public string mandate_id { get; set; }
        
            public string reference { get; set; }
        
            public string return_url { get; set; }
        
            public State state { get; set; }
        
            public Links _links { get; set; }
        
            public DateTime created_date { get; set; }
        
            public string description { get; set; }
        
            public string payment_provider { get; set; }
    }
}