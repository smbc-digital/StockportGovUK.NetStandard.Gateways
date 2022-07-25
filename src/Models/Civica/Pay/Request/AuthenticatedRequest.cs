namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class AuthenticatedRequest
    {
        public string CallingAppIdentifier { get; set; }

        public string CustomerID { get; set; }

        public string ApiPassword { get; set; }
    }
}