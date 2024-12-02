using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserve;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{

    public class PermiserveGateway : Gateway, IPermiserviceGateway
    {
        public PermiserveGateway(HttpClient httpClient) : base(httpClient) { }

        public async Task<HttpResponse<GetPermitResponse>> GetPermit(GetPermitRequest request)
        {
            var content = new MultipartFormDataContent();
            content.AddIfNotNull(request.ApiKey, "apiKey");
            content.Add(new StringContent("search"), "callType");
            content.AddIfNotNull(request.ReturnType, "returnType");
            content.AddIfNotNull(request.PermitAddress, "permitAddress");
            content.AddIfNotNull(request.Uprn, "uprn");
            content.AddIfNotNull(request.CouncilJobNumber, "councilJobNumber");
            content.Add(new StringContent(request.Cancelled.ToString()), "Cancelled");
            content.AddIfNotNull(request.NotificationEmail, "notificationEmail");
            
            if(request.PermitType != PermitType.Unknown)
                content.Add(new StringContent(request.PermitType.ToString()), "permitType");
    
            if(request.PermitState != PermitState.Unknown)
                content.Add(new StringContent(request.PermitState.ToString()), "state");

            return await PostAsync<GetPermitResponse>(string.Empty, content, false);
        }

        public async Task<HttpResponse<PermiServeResponse>> CreatePermit(CreatePermitRequest request)
        {
            var content = new MultipartFormDataContent();
            content.AddIfNotNull(request.ApiKey, "apiKey");
            content.Add(new StringContent("insert"), "callType");
            content.AddIfNotNull(request.ReturnType, "returnType");
            content.AddIfNotNull(request.PermitAddress, "permitAddress");
            content.AddIfNotNull(request.Uprn, "uprn");
            content.AddIfNotNull(request.CouncilJobNumber, "councilJobNumber");
            content.AddIfNotNull(request.NotificationEmail, "notificationEmail");
            content.AddIfNotNull(request.NotificationTelephone, "notificationTelephone");

            return await PostAsync<PermiServeResponse>(string.Empty, content, false);
        }
    }
}
