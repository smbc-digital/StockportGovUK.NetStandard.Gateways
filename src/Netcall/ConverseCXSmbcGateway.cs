using System.Net.Http;

namespace StockportGovUK.NetStandard.Gateways.Netcall
{
    public class ConverseCXSmbcGateway : ConverseCXBaseGateway, IConverseCXGateway
    {
        public ConverseCXSmbcGateway(HttpClient httpClient) : base(httpClient)
        {}
    }
}