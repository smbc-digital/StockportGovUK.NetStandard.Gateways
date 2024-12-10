using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUk.NetStandard.Gateways.Models.Permiserv;
using StockportGovUK.NetStandard.Gateways.Extensions;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.Permiserv;

public class PermiservGateway : Gateway, IPermiservGateway
{
    public PermiservGateway(HttpClient httpClient) : base(httpClient) { }

    public async Task<HttpResponse<GetPermitResponse>> GetPermit(GetPermitRequest request)
    {
        var content = new MultipartFormDataContent();
        content.AddIfNotNull(request.ApiKey, "apiKey");
        content.Add(new StringContent("search"), "callType");
        content.AddIfNotNull(request.ReturnType, "returnType");
        content.AddIfNotNull(request.PermitAddress, "permitAddress");

        //content.AddIfNotNull(request.PermitId, "permitId");
        //content.AddIfNotNull(request.Uprn, "uprn");
        //content.AddIfNotNull(request.CouncilJobNumber, "councilJobNumber");
        //content.AddIfNotNull(request.NotificationEmail, "notificationEmail");
            
        //if(request.Cancelled)
        //    content.Add(new StringContent("1", "cancelled");

        //if(request.PermitType != PermitType.Unknown)
        //    content.Add(new StringContent(request.PermitType.ToString()), "permitType");

        //if(request.PermitState != PermitState.Unknown)
        //    content.Add(new StringContent(request.PermitState.ToString()), "state");

        var result = await PostAsync<GetPermitResponse>("/api/", content, false);
        return result;
    }

    public async Task<HttpResponse<CreatePermitResponse>> CreatePermit(CreatePermitRequest request)
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
        content.AddIfNotNull(request.ExpiryDate, "expiryDate");
        content.AddIfNotNull(request.Quantity.ToString(), "quantity");

        return await PostAsync<CreatePermitResponse>("/api/", content, false);
    }
}