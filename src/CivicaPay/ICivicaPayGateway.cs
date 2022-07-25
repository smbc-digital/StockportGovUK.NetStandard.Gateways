using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Request;
using StockportGovUK.NetStandard.Gateways.Models.Civica.Pay.Response;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.CivicaPay
{
    public interface ICivicaPayGateway
    {
        Task<HttpResponse<CreateBasketResponse>> CreateBasketAsync(CreateBasketRequest request);

        Task<HttpResponse<AddItemResponse>> AddItemAsync(AddItemRequest request);

        Task<HttpResponse<RemoveItemResponse>> RemoveItemAsync(RemoveItemRequest request);

        Task<HttpResponse<CreateImmediateBasketResponse>> CreateImmediateBasketAsync(CreateImmediateBasketRequest request);

        Task<HttpResponse<FullBasketSummaryResponse>> GetFullBasketSummary(BasketSummaryRequest request);

        Task<HttpResponse<CatalogueItemListResponse>> GetCatalogueItemsAsync(CatalogueItemListRequest request);

        Task<HttpResponse<BasketSecurityDetailsResponse>> GetBasketSecurityDetails(BasketSecurityDetailsRequest request);

        string GetPaymentUrl(string basketReference, string basketToken, string reference);
    }
}