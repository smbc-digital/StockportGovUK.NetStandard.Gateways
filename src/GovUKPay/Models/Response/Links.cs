namespace StockportGovUK.NetStandard.Gateways.GovUKPay.Models.Response
{
    public class Links
    {
        public Self self { get; set; }

        public NextUrl next_url { get; set; }

        public NextUrlPost next_url_post { get; set; }

        public Payments payments { get; set; }
    }
}