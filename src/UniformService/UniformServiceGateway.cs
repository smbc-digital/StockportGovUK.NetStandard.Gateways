using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Uniform;
using StockportGovUK.NetStandard.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
    public class UniformServiceGateway : Gateway, IUniformServiceGateway
    {
        private const string PestControlEndpoint = "api/v1/PestControl";
        private const string NoiseNuisanceEndpoint = "api/v1/NoiseNuisance";
        private const string BonfireNuisanceEndpoint = "api/v1/BonfireNuisance";

        public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public async Task<HttpResponse<string>> GetPestControlRequest(string id)
            => await GetAsync<string>($"{PestControlEndpoint}?reference={id}");

        public async Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request)
            => await PostAsync<string>($"{PestControlEndpoint}", request);

        public async Task<HttpResponse<string>> CreateNoiseNuisanceRequest(NoiseNuisanceServiceRequest request)
            => await PostAsync<string>($"{NoiseNuisanceEndpoint}", request);

        public async Task<HttpResponse<string>> CreateBonfireNuisanceRequest(BonfireNuisanceServiceRequest request)
    => await PostAsync<string>($"{BonfireNuisanceEndpoint}", request);

    }
}
