using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Request;
using StockportGovUK.NetStandard.Gateways.Models.Whitespace.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WhitespaceService;
public class WhitespaceServiceGateway : Gateway, IWhitespaceServiceGateway
{
    private const string AddressEndpoint = "api/v1/Address";
    private const string SiteEndpoint = "api/v1/Site";
    private const string CollectionEndpoint = "api/v1/Collection";
    private const string WorksheetEndpoint = "api/v1/Worksheet";
    private const string StreetEndpoint = "api/v1/Street";
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

    #endregion

    #region Site

    public async Task<HttpResponse<SiteResponse>> GetSiteInfo(SiteInfoRequest request)
        => await GetAsync<SiteResponse>($"{SiteEndpoint}/sites{GetSiteInfoQueryString(request)}");

    public async Task<HttpResponse<SiteIdResponse>> GetAccountSiteId(AccountSiteIdRequest request)
        => await GetAsync<SiteIdResponse>($"{SiteEndpoint}/account-site-id{GetAccountSiteIdQueryString(request)}");

    #endregion

    #region Street

    public async Task<HttpResponse<StreetResponse>> GetStreets(string postcode)
        => await GetAsync<StreetResponse>($"{StreetEndpoint}/{postcode}");

    #endregion

    #region Worksheet

    public async Task<HttpResponse<WorksheetResponse>> GetSiteWorksheets(SiteWorksheetsRequest request)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/site-worksheets{GetSiteWorksheetsQueryString(request)}");

    #endregion

    #region Query String Generators

    private string GetCollectionByUprnAndDateQueryString(CollectionRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    private string GetSiteInfoQueryString(SiteInfoRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.AccountSiteId)}={request.AccountSiteId}";

    private string GetAccountSiteIdQueryString(AccountSiteIdRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.SiteId)}={request.SiteId}";

    private string GetSiteWorksheetsQueryString(SiteWorksheetsRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.WorksheetSubject)}={request.WorksheetSubject}";

    private string GetInCabLogsQueryString(InCabLogRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.Usrn)}={request.Usrn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    #endregion
}
