using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.AdvicePro;

public class AdviceProGateway : Gateway, IAdviceProGateway
{
    public AdviceProGateway(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<HttpResponseMessage> CreateReferral(object request)
        => await PostAsync("referrals", request);
}
