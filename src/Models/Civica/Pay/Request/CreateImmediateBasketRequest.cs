using System.Collections.Generic;

namespace StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request
{
    public class CreateImmediateBasketRequest : CreateBasketRequestBase
    {

        public string NotifyURL { get; set; }

        public string UserName { get; set; }

        public List<PaymentItem> PaymentItems { get; set; }
    }
}