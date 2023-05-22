using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Uniform;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
	public interface IUniformServiceGateway
	{
		Task<HttpResponse<string>> GetPestControlRequest(string id);
		Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request);
		Task<HttpResponse<string>> ResubmitPestControlRequest(string crmCaseId);
		Task<HttpResponse<string>> CreateNoiseNuisanceRequest(NoiseNuisanceServiceRequest request);
		Task<HttpResponse<string>> ResubmitNoiseNuisanceRequest(string crmCaseId);
		Task<HttpResponse<string>> CreateBonfireNuisanceRequest(BonfireNuisanceServiceRequest request);
		Task<HttpResponse<string>> ResubmitBonfireNuisanceRequest(string crmCaseId);
		Task<HttpResponse<string>> CreateHousingDisrepairServiceRequest(HousingDisrepairServiceRequest request);
		Task<HttpResponse<string>> ResubmitHousingDisrepairServiceRequest(string crmCaseId);
		Task<HttpResponse<string>> CreateTaxiLicenceRequest(TaxiLicensingServiceRequest request);
		Task<HttpResponse<string>> UpdateTaxiLicenceRequestWithPayment(TaxiLicensingUpdateRequest request);
		Task<HttpResponse<string>> UpdateTaxiLicenceRequestWithDetails(TaxiLicensingUpdateRequest request);
		Task<HttpResponse<string>> CheckTaxiLicenceRequestIsOpen(TaxiLicensingUpdateRequest request);
	}
}
