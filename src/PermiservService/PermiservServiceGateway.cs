using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserv;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.PermiservService;

public class PermiservServiceGateway : Gateway, IPermiservServiceGateway
{
    private const string HomeEndpoint = "api/v1/Home";

    public PermiservServiceGateway(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<HttpResponse<CreatePermitResponse>> CreatePermit(CreatePermitRequest request)
        => await PostAsync<CreatePermitResponse>($"{HomeEndpoint}", request);

    public async Task<HttpResponse<CreatePermitResponse>> FakeCreatePermit(CreatePermitRequest request)
        => await PostAsync<CreatePermitResponse>($"{HomeEndpoint}/fake", request);
}
