using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserv;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.Permiserv;

public interface IPermiservGateway : IGateway {
    Task<HttpResponse<GetPermitResponse>> GetPermit(GetPermitRequest request);
    Task<HttpResponse<CreatePermitResponse>> CreatePermit(CreatePermitRequest request);
}