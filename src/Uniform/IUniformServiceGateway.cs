using StockportGovUK.NetStandard.Gateways.Response;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.Uniform;


namespace StockportGovUK.NetStandard.Gateways.Uniform
{
    interface IUniformServiceGateway
    {
        Task<HttpResponse<string>> CreateBonfireNuisanceCase(BonfireNuisanceServiceRequest bonfireNuisanceServiceRequest);
        Task<HttpResponse<string>> CreateNoiseNuisanceCase(NoiseNuisanceServiceRequest noiseNuisanceServiceRequest);
        Task<HttpResponse<string>> CreatePestControlCase(PestControlServiceRequest pestControlServiceRequest);
    }
}
