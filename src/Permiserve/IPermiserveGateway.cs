using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserve;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.Permiserve
{
    public interface IPermiserveGateway {
        Task<HttpResponse<GetPermitResponse>> GetPermit(GetPermitRequest request);
        Task<HttpResponse<CreatePermitResponse>> CreatePermit(CreatePermitRequest request);
    }
}
