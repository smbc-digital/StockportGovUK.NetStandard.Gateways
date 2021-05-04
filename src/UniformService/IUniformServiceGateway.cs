using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Verint;

namespace StockportGovUK.NetStandard.Gateways.UniformService
{
    public interface IUniformServiceGateway
    {
        Task<HttpResponse<Case>> GetPestControlRequest(string id);
        Task<HttpResponse<string>> CreatePestControlRequest(Case crmCase);
    }
}
