using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Uniform;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
	public class UniformServiceGateway : Gateway, IUniformServiceGateway
	{
		private const string PestControlEndpoint = "api/v1/PestControl";

		private const string NoiseNuisanceEndpoint = "api/v1/NoiseNuisance";

		private const string BonfireNuisanceEndpoint = "api/v1/BonfireNuisance";

		private const string HousingDisrepairEndpoint = "api/v1/HousingDisrepair";

		private const string TaxiLicenceEndpoint = "api/v1/TaxiLicensing";

		private const string TaxiLicenceEndpointWithPayment = "api/v1/TaxiLicensing/UpdateWithPayment";

		private const string TaxiLicenceEndpointWithDetails = "api/v1/TaxiLicensing/UpdateWithDetails";

		private const string TaxiLicenceEndpointCheckIsOpen = "api/v1/TaxiLicensing/CheckIsOpen";

		public UniformServiceGateway(HttpClient httpClient) : base(httpClient)
		{
		}

		public async Task<HttpResponse<string>> GetPestControlRequest(string id)
			=> await GetAsync<string>($"{PestControlEndpoint}?reference={id}");

		public async Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request)
			=> await PostAsync<string>($"{PestControlEndpoint}", request);

		public async Task<HttpResponse<string>> ResubmitPestControlRequest(string crmCaseId)
			=> await PostAsync<string>($"{PestControlEndpoint}/Resubmit", crmCaseId);

        public async Task<HttpResponseMessage> ClosePestControlRequest(PestControlCloseServiceRequest request)
            => await PatchAsync($"{PestControlEndpoint}/close", request);

		public async Task<HttpResponse<string>> CreateNoiseNuisanceRequest(NoiseNuisanceServiceRequest request)
			=> await PostAsync<string>($"{NoiseNuisanceEndpoint}", request);

		public async Task<HttpResponse<string>> ResubmitNoiseNuisanceRequest(string crmCaseId)
			=> await PostAsync<string>($"{NoiseNuisanceEndpoint}/ResubmitCase", crmCaseId);

		public async Task<HttpResponse<string>> CreateBonfireNuisanceRequest(BonfireNuisanceServiceRequest request)
			=> await PostAsync<string>($"{BonfireNuisanceEndpoint}", request);

		public async Task<HttpResponse<string>> ResubmitBonfireNuisanceRequest(string crmCaseId)
			=> await PostAsync<string>($"{BonfireNuisanceEndpoint}/ResubmitCase", crmCaseId);

		public async Task<HttpResponse<string>> CreateHousingDisrepairServiceRequest(HousingDisrepairServiceRequest request)
			=> await PostAsync<string>($"{HousingDisrepairEndpoint}", request);

		public async Task<HttpResponse<string>> ResubmitHousingDisrepairServiceRequest(string crmCaseId)
			=> await PostAsync<string>($"{HousingDisrepairEndpoint}/ResubmitCase", crmCaseId);

		public async Task<HttpResponse<string>> CreateTaxiLicenceRequest(TaxiLicensingServiceRequest request)
			=> await PostAsync<string>($"{TaxiLicenceEndpoint}", request);

		public async Task<HttpResponse<string>> UpdateTaxiLicenceRequestWithPayment(TaxiLicensingUpdateRequest request)
			=> await PatchAsync<string>($"{TaxiLicenceEndpointWithPayment}", request);

		public async Task<HttpResponse<string>> UpdateTaxiLicenceRequestWithDetails(TaxiLicensingUpdateRequest request)
			=> await PatchAsync<string>($"{TaxiLicenceEndpointWithDetails}", request);

		public async Task<HttpResponse<string>> CheckTaxiLicenceRequestIsOpen(TaxiLicensingUpdateRequest request)
			=> await PostAsync<string>($"{TaxiLicenceEndpointCheckIsOpen}", request);
	}
}
