using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.AdvicePro;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.AdvicePro;

public class AdviceProGateway : Gateway, IAdviceProGateway
{
    public AdviceProGateway(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<HttpResponse<GetResponse>> GetContract(string apiKey, string contractKey)
        => await GetAsync<GetResponse>($"referrals?agencyAPIKey={apiKey}&contractKey={contractKey}");

    public async Task<HttpResponse<PostResponse>> CreateReferral(object request)
        => await PostAsync<PostResponse>("referrals", request);
}
