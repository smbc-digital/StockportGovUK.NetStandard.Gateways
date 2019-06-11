using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Verint;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public interface IFosteringServiceGateway
    {
        Task<HttpResponse<Case>> GetCase(string caseRef);
    }
}
