using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Uniform;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
    public interface IUniformServiceGateway
    {
        Task<HttpResponse<string>> GetPestControlRequest(string id);
        Task<HttpResponse<string>> CreatePestControlRequest(PestControlServiceRequest request);
        Task<HttpResponse<string>> CreateNoiseNuisanceRequest(NoiseNuisanceServiceRequest request);
        Task<HttpResponse<string>> CreateBonfireNuisanceRequest(BonfireNuisanceServiceRequest request);
    }
}
