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

    public async Task<HttpResponse<InCabLogResponse>> GetInCabLogsByUsrn(InCabLogRequest request)
        => await GetAsync<InCabLogResponse>($"{CollectionEndpoint}/in-cab-usrn/{GetInCabLogsByUsrnQueryString(request)}");

    public async Task<HttpResponse<InCabLogResponse>> GetInCabLogsByUprn(InCabLogRequest request)
        => await GetAsync<InCabLogResponse>($"{CollectionEndpoint}/in-cab-uprn/{GetInCabLogsByUprnQueryString(request)}");

    #endregion

    #region Site

    public async Task<HttpResponse<SiteResponse>> GetSiteInfoByUprn(string uprn)
        => await GetAsync<SiteResponse>($"{SiteEndpoint}/site-info-uprn/{uprn}");

    public async Task<HttpResponse<SiteIdResponse>> GetAccountSiteIdByUprn(string uprn)
        => await GetAsync<SiteIdResponse>($"{SiteEndpoint}/account-site-id-uprn/{uprn}");

    #endregion

    #region Street

    public async Task<HttpResponse<StreetResponse>> GetStreets(string postcode)
        => await GetAsync<StreetResponse>($"{StreetEndpoint}/{postcode}");

    #endregion

    #region Worksheet

    public async Task<HttpResponse<WorksheetResponse>> GetSiteWorksheets(string uprn)
        => await GetAsync<WorksheetResponse>($"{WorksheetEndpoint}/{uprn}");

    #endregion

    #region Query String Generators

    private string GetCollectionByUprnAndDateQueryString(CollectionRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    private string GetInCabLogsByUprnQueryString(InCabLogRequest request) =>
        $"?{nameof(request.Uprn)}={request.Uprn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    private string GetInCabLogsByUsrnQueryString(InCabLogRequest request) =>
        $"?{nameof(request.Usrn)}={request.Usrn}&{nameof(request.From)}={request.From:s}&{nameof(request.To)}={request.To:s}";

    #endregion
}
