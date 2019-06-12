using System.Threading.Tasks;
using StockportGovUK.AspNetCore.Gateways.Response;
using StockportGovUK.NetStandard.Models.Models.Fostering;

namespace StockportGovUK.AspNetCore.Gateways.FosteringServiceGateway
{
    public interface IFosteringServiceGateway
    {
        Task<HttpResponse<FosteringCase>> GetCase(string caseRef);
    }
}
