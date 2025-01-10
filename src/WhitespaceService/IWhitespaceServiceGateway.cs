using System.Net.Http;
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
    Task<HttpResponse<SiteServiceResponse>> GetSiteCollections(SiteServiceRequest request);
    Task<HttpResponse<SiteServiceScheduleResponse>> GetSiteAvailableRounds(string uprn);
    Task<HttpResponseMessage> UpdateSiteServiceItem(UpdateSiteServiceItemRequest request);
    Task<HttpResponseMessage> FakeUpdateSiteServiceItem(UpdateSiteServiceItemRequest request);
    Task<HttpResponseMessage> AddSiteServiceItemRoundSchedule(AddSiteServiceItemRoundScheduleRequest request);
    Task<HttpResponse<RoundIncidentResponse>> GetRoundIncidents(string uprn);
    Task<HttpResponse<SiteResponse>> GetSiteInfo(SiteInfoRequest request);
    Task<HttpResponse<SiteIdResponse>> GetAccountSiteId(AccountSiteIdRequest request);
    Task<HttpResponse<SiteNotificationsResponse>> GetSiteNotifications(string uprn);
    Task<HttpResponse<StreetResponse>> GetStreets(string postcode);
    Task<HttpResponse<WorksheetResponse>> GetSiteWorksheets(SiteWorksheetsRequest request);
    Task<HttpResponse<WorksheetResponse>> GetOpenSiteWorksheets(string uprn);
    Task<HttpResponse<string>> CreateWorksheet(CreateWorksheetRequest request);
    Task<HttpResponse<string>> FakeCreateWorksheet(CreateWorksheetRequest request);
    Task<HttpResponseMessage> CancelWorksheet(CancelWorksheetRequest request);
    Task<HttpResponseMessage> AddWorksheetNote(AddWorksheetNoteRequest request);
    Task<HttpResponse<ServiceItemResponse>> GetServiceItems(string serviceId);
    Task<HttpResponse<ServiceItemResponse>> GetWorksheetServiceItems(string serviceId, string uprn);
    Task<HttpResponse<WorksheetResponse>> GetWorksheetDetails(string worksheetId);
    Task<HttpResponse<WorksheetResponse>> GetWorksheetDetailsByCaseReference(string caseReference);
}
