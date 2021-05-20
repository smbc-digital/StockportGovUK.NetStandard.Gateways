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
        

        public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public async Task<HttpResponse<string>> GetPestControlRequest(string id)
            => await GetAsync<string>($"{PestControlEndpoint}?reference={id}");

        public async Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request)
            => await PostAsync<string>($"{PestControlEndpoint}", request);
    }
}
