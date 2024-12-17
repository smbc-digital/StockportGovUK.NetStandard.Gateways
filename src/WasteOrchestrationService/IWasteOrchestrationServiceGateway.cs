using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WasteOrchestrationService;
public interface IWasteOrchestrationServiceGateway
{
    Task<HttpResponse<string>> ProcessWorksheetRequest(CreateWorksheetRequest request);
    Task<HttpResponse<string>> ProcessPermitWorksheetRequest(CreatePermitWorksheetRequest request);
}
