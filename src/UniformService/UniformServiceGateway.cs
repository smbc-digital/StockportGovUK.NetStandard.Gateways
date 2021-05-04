using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
    public class UniformServiceGateway : Gateway, IUniformServiceGateway
    {
        private const string PestControlEndpoint = "api/v1/PestControl";
        

        public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public async Task<HttpResponse<Case>> GetPestControlRequest(string id)
            => await GetAsync<Case>($"{PestControlEndpoint}?reference={id}");

        public async Task<HttpResponse<string>> CreatePestControlRequest(Case crmCase)
            => await PostAsync<string>($"{PestControlEndpoint}", crmCase);
    }
}
