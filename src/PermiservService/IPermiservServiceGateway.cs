using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserv;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.PermiservService;

public interface IPermiservServiceGateway
{
    Task<HttpResponse<CreatePermitResponse>> CreatePermit(CreatePermitRequest request);
    Task<HttpResponse<CreatePermitResponse>> FakeCreatePermit(CreatePermitRequest request);
}
