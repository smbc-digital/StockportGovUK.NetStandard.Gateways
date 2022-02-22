using StockportGovUK.NetStandard.Models.Uniform;
using StockportGovUK.NetStandard.Gateways.Response;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Uniform
{
    public class UniformServiceGateway :Gateway, IUniformServiceGateway
    {

        private const string BonfireNuisanceEndpoint = "api/v1/BonfireNuisance";
        private const string NoiseNuisanceEndpoint = "api/v1/NoiseNuisance";
        private const string PestControlEndpoint = "api/v1/PestControl";
        public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponse<string>> CreateBonfireNuisanceCase(BonfireNuisanceServiceRequest bonfireNuisanceServiceRequest)
            => await PostAsync<string>($"{BonfireNuisanceEndpoint}", bonfireNuisanceServiceRequest);
            
        public async Task<HttpResponse<string>> CreateNoiseNuisanceCase(NoiseNuisanceServiceRequest request)
            => await PostAsync<string>($"{NoiseNuisanceEndpoint}", request);
        public async Task<HttpResponse<string>> CreatePestControlCase(PestControlServiceRequest request)
            => await PostAsync<string>($"{PestControlEndpoint}", request);
    }
}
