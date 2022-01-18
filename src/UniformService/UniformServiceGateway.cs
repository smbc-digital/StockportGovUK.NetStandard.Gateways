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
        private const string HousingDisrepairEndpoint = "api/v1/HousingDisrepair";
        public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
        {
        }
        
        public async Task<HttpResponse<string>> GetPestControlRequest(string id)
            => await GetAsync<string>($"{PestControlEndpoint}?reference={id}");

        public async Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request)
            => await PostAsync<string>($"{PestControlEndpoint}/CreateCase", request);

        public async Task<HttpResponse<string>> ResubmitPestControlRequest(string crmCaseId)
            => await PostAsync<string>($"{PestControlEndpoint}/Resubmit", crmCaseId);

        public async Task<HttpResponse<string>> CreateNoiseNuisanceRequest(NoiseNuisanceServiceRequest request)
            => await PostAsync<string>($"{NoiseNuisanceEndpoint}/CreateCase", request);

        public async Task<HttpResponse<string>> ResubmitNoiseNuisanceRequest(string crmCaseId)
           => await PostAsync<string>($"{NoiseNuisanceEndpoint}/ResubmitCase", crmCaseId);

        public async Task<HttpResponse<string>> CreateBonfireNuisanceRequest(BonfireNuisanceServiceRequest request)
            => await PostAsync<string>($"{BonfireNuisanceEndpoint}/CreateCase", request);

        public async Task<HttpResponse<string>> ResubmitBonfireNuisanceRequest(string crmCaseId)
            => await PostAsync<string>($"{BonfireNuisanceEndpoint}/ResubmitCase", crmCaseId);

        public async Task<HttpResponse<string>> CreateHousingDisrepairServiceRequest(BonfireNuisanceServiceRequest request)
           => await PostAsync<string>($"{HousingDisrepairEndpoint}/CreateCase", request);

        public async Task<HttpResponse<string>> ResubmitHousingDisrepairServiceRequest(string crmCaseId)
            => await PostAsync<string>($"{HousingDisrepairEndpoint}/ResubmitCase", crmCaseId);

    }
}
