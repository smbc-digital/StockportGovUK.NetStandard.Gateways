namespace StockportGovUK.AspNetCore.Gateways.GovUK.Pay
{
    public class MandateSetupRequest
    {
        public string reference { get; set; }

        public string return_url { get; set; }

        public string description  { get; set; }
    }
}