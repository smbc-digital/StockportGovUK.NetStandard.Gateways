using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WhitespaceService;
public class WhitespaceServiceGateway : Gateway, IWhitespaceServiceGateway
{
    private const string AddressEndpoint = "api/v1/Address";
    private const string CollectionEndpoint = "api/v1/Collection";
    private const string SiteEndpoint = "api/v1/Site";
    private const string StreetEndpoint = "api/v1/Street";
    private const string WorksheetEndpoint = "api/v1/Worksheet";
    
    public WhitespaceServiceGateway(HttpClient httpClient) : base(httpClient)
    {
    }

    #region Address

    public async Task<HttpResponse<AddressResponse>> GetAddresses(string postcode)
        => await GetAsync<AddressResponse>($"{AddressEndpoint}/{postcode}");

    #endregion

    #region Collection

    public async Task<HttpResponse<CollectionResponse>> GetCollectionByUprnAndDate(CollectionRequest request)
        => await GetAsync<CollectionResponse>($"{CollectionEndpoint}{GetCollectionByUprnAndDateQueryString(request)}");

    public async Task<HttpResponse<InCabLogResponse>> GetInCabLogs(InCabLogRequest request)
        => await GetAsync<InCabLogResponse>($"{CollectionEndpoint}/in-cab-logs{GetInCabLogsQueryString(request)}");

    public async Task<HttpResponse<AdHocRoundResponse>> GetCollectionSlots(CollectionSlotsRequest request)
        => await GetAsync<AdHocRoundResponse>($"{CollectionEndpoint}/collection-slots{GetCollectionSlotsQueryString(request)}");

    public async Task<HttpResponse<SiteServiceResponse>> GetSiteCollections(SiteServiceRequest request)
        => await GetAsync<SiteServiceResponse>($"{CollectionEndpoint}/site-collections{GetSiteCollectionsQueryString(request)}");

    public async Task<HttpResponse<SiteServiceScheduleResponse>> GetSiteAvailableRounds(string uprn)
        => await GetAsync<SiteServiceScheduleResponse>($"{CollectionEndpoint}/site-available-rounds/{uprn}");

    public async Task<HttpResponseMessage> UpdateSiteServiceItem(UpdateSiteServiceItemRequest request)
        => await PatchAsync($"{CollectionEndpoint}/site-service-item", request);

    public async Task<HttpResponseMessage> FakeUpdateSiteServiceItem(UpdateSiteServiceItemRequest request)
        => await PatchAsync($"{CollectionEndpoint}/fake-site-service-item", request);

    public async Task<HttpResponseMessage> AddSiteServiceItemRoundSchedule(AddSiteServiceItemRoundScheduleRequest request)
        => await PatchAsync($"{CollectionEndpoint}/site-service-item-round-schedule", request);

    public async Task<HttpResponse<RoundIncidentResponse>> GetRoundIncidents(string uprn)
        => await GetAsync<RoundIncidentResponse>($"{CollectionEndpoint}/round-incidents/{uprn}");

    #endregion

    #region Site

    public async Task<HttpResponse<SiteResponse>> GetSiteInfo(SiteInfoRequest request)
        => await GetAsync<SiteResponse>($"{SiteEndpoint}/sites{GetSiteInfoQueryString(request)}");

    public async Task<HttpResponse<SiteIdResponse>> GetAccountSiteId(AccountSiteIdRequest request)
        => await GetAsync<SiteIdResponse>($"{SiteEndpoint}/account-site-id{GetAccountSiteIdQueryString(request)}");

    public async Task<HttpResponse<SiteNotificationsResponse>> GetSiteNotifications(string uprn)
        => await GetAsync<SiteNotificationsResponse>($"{SiteEndpoint}/notifications/{uprn}");

    #endregion

    #region Street

    public async Task<HttpResponse<StreetResponse>> GetStreets(string postcode)
        => await GetAsync<StreetResponse>($"{StreetEndpoint}/{postcode}");

    #endregion

    #region Worksheet

    public async Task<HttpResponse<WorksheetResponse>> GetSiteWorksheets(SiteWorksheetsRequest request)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/site-worksheets{GetSiteWorksheetsQueryString(request)}");

    public async Task<HttpResponse<WorksheetResponse>> GetOpenSiteWorksheets(string uprn)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/open-site-worksheets/{uprn}");

    public async Task<HttpResponse<string>> CreateWorksheet(CreateWorksheetRequest request)
        => await PostAsync<string>($"{WorksheetEndpoint}", request);

    public async Task<HttpResponse<string>> FakeCreateWorksheet(CreateWorksheetRequest request)
        => await PostAsync<string>($"{WorksheetEndpoint}/fake", request);

    public async Task<HttpResponseMessage> CancelWorksheet(CancelWorksheetRequest request)
        => await PatchAsync($"{WorksheetEndpoint}", request);

    public async Task<HttpResponseMessage> AddWorksheetNote(AddWorksheetNoteRequest request)
        => await PatchAsync($"{WorksheetEndpoint}/note", request);

    public async Task<HttpResponse<ServiceItemResponse>> GetServiceItems(string serviceId)
        => await GetAsync<ServiceItemResponse>($"{WorksheetEndpoint}/service-items/{serviceId}");

    public async Task<HttpResponse<ServiceItemResponse>> GetWorksheetServiceItems(string serviceId, string uprn)
        => await GetAsync<ServiceItemResponse>($"{WorksheetEndpoint}/worksheet-service-items/{serviceId}/property/{uprn}");

    public async Task<HttpResponse<WorksheetResponse>> GetWorksheetDetails(string worksheetId)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/{worksheetId}");

    public async Task<HttpResponse<WorksheetResponse>> GetWorksheetDetailsByCaseReference(string caseReference)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/case-reference/{caseReference}");

    #endregion

    #region Query String Generators

    private string GetCollectionByUprnAndDateQueryString(CollectionRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.From)}={request.From:dd/MM/yyyy}&{nameof(request.To)}={request.To:dd/MM/yyyy}";

    private string GetCollectionSlotsQueryString(CollectionSlotsRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.ServiceId)}={request.ServiceId}&{nameof(request.SearchToDate)}={request.SearchToDate:s}";

    private string GetSiteInfoQueryString(SiteInfoRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.AccountSiteId)}={request.AccountSiteId}";

    private string GetAccountSiteIdQueryString(AccountSiteIdRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.SiteId)}={request.SiteId}";

    private string GetSiteWorksheetsQueryString(SiteWorksheetsRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.WorksheetSubject)}={request.WorksheetSubject}";

    private string GetInCabLogsQueryString(InCabLogRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.Usrn)}={request.Usrn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    private string GetSiteCollectionsQueryString(SiteServiceRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.SiteId)}={request.SiteId}";

    #endregion
}
