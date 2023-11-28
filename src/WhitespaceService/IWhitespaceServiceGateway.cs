using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WhitespaceService;
public interface IWhitespaceServiceGateway
{
    Task<HttpResponse<AddressResponse>> GetAddresses(string postcode);
    Task<HttpResponse<CollectionResponse>> GetCollectionByUprnAndDate(CollectionRequest request);
    Task<HttpResponse<InCabLogResponse>> GetInCabLogs(InCabLogRequest request);
    Task<HttpResponse<AdHocRoundResponse>> GetCollectionSlots(CollectionSlotsRequest request);
    Task<HttpResponse<SiteResponse>> GetSiteInfo(SiteInfoRequest request);
    Task<HttpResponse<SiteIdResponse>> GetAccountSiteId(AccountSiteIdRequest request);
    Task<HttpResponse<StreetResponse>> GetStreets(string postcode);
    Task<HttpResponse<WorksheetResponse>> GetSiteWorksheets(SiteWorksheetsRequest request);
    Task<HttpResponse<string>> CreateWorksheet(CreateWorksheetRequest request);
}
