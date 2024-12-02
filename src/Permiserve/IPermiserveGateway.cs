using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserve;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public interface IPermiserveGateway {
        Task<HttpResponse<GetPermitResponse>> GetPermit(GetPermitRequest request);
        Task<HttpResponse<PermiserveResponse>> CreatePermit(CreatePermitRequest request);
    }
}
