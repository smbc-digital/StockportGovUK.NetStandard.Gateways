using System.Net.Http;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseCXGateway : ConverseCXBaseGateway, IConverseCXGateway
    {
        public ConverseCXGateway(HttpClient httpClient) : base(httpClient)
        {}
    }
}