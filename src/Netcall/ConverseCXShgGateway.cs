using System.Net.Http;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseCXShgGateway : ConverseCXBaseGateway, IConverseCXGateway
    {
        public ConverseCXShgGateway(HttpClient httpClient) : base(httpClient)
        {}
    }
}