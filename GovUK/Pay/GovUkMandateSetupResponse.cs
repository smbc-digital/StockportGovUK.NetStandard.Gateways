using System;

namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
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

    public class State
    {
        public string status { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class NextUrl
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class Params
    {
        public string chargeTokenId { get; set; }
    }

    public class NextUrlPost
    {
        public string type { get; set; }
        public Params @params { get; set; }
        public string href { get; set; }
        public string method { get; set; }
    }

    public class Payments
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public NextUrl next_url { get; set; }
        public NextUrlPost next_url_post { get; set; }
        public Payments payments { get; set; }
    }
}