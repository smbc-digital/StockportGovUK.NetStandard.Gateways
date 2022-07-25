using System;

namespace StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response
{
    public class GovUkMandateStatusResponse
    {
        public string mandate_id { get; set; }

        public string provider_id { get; set; }

        public string reference { get; set; }

        public string return_url { get; set; }

        public State state { get; set; }

        public Links _links { get; set; }

        public string bank_statement_reference { get; set; }

        public DateTime created_date { get; set; }

        public string description { get; set; }

        public string payment_provider { get; set; }

        public Payer payer { get; set; }
    }
}