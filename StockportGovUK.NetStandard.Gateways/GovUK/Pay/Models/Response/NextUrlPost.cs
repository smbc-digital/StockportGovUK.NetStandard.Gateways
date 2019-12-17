namespace StockportGovUK.NetStandard.Gateways.GovUK.Pay
{
    public class NextUrlPost
    {
        public string type { get; set; }
        
        public Params @params { get; set; }     
        public string href { get; set; }

        public string method { get; set; }
    }
}