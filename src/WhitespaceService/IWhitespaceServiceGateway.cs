using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WhitespaceService;
public interface IWhitespaceServiceGateway
{
    Task<HttpResponse<AddressResponse>> GetAddresses(string postcode);
    Task<HttpResponse<SiteResponse>> GetSiteInfoByUprn(string uprn);
    Task<HttpResponse<SiteIdResponse>> GetAccountSiteIdByUprn(string uprn);
    Task<HttpResponse<CollectionResponse>> GetCollectionByUprnAndDate(CollectionRequest request);
    Task<HttpResponse<WorksheetResponse>> GetSiteWorksheetsByUprn(string uprn);
    Task<HttpResponse<StreetResponse>> GetStreets(string postcode);
    Task<HttpResponse<InCabLogResponse>> GetInCabLogsByUsrn(InCabLogRequest request);
    Task<HttpResponse<InCabLogResponse>> GetInCabLogsByUprn(InCabLogRequest request);
}
