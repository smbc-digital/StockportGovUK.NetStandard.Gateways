using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Civica.Pay.Request;
using StockportGovUK.NetStandard.Models.Civica.Pay.Response;

namespace StockportGovUK.NetStandard.Gateways.CivicaPay
{
    public class CivicaPayGateway : Gateway, ICivicaPayGateway
    {
        private const string ApiRoot = "StockportEstore/TransportableBasket/api";
        private const string PaymentUrl = "{0}/estore/default/Remote/Fetch?basketreference={1}&baskettoken={2}&callingapptxnreference={3}&backsitename=Stockport%20Homepage&backurl=https://www.stockport.gov.uk";

        public CivicaPayGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        private string EStoreRoot => $"{Client.BaseAddress}StockportEstore";

        public string GetPaymentUrl(string basketReference, string basketToken, string reference)
            => string.Format(PaymentUrl , EStoreRoot, basketReference, basketToken, reference);

        public async Task<HttpResponse<CreateBasketResponse>> CreateBasketAsync(CreateBasketRequest request)
        {
            var response = await PostAsync<CreateBasketResponse>($"{ApiRoot}/BasketApi/Create", request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<AddItemResponse>> AddItemAsync(AddItemRequest request)
        {
            var response = await PostAsync<AddItemResponse>($"{ApiRoot}/BasketApi/AddItem", request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<RemoveItemResponse>> RemoveItemAsync(RemoveItemRequest request)
        {
            var response = await PostAsync<RemoveItemResponse>($"{ApiRoot}/BasketApi/RemoveItem", request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<CreateImmediateBasketResponse>> CreateImmediateBasketAsync(CreateImmediateBasketRequest request)
        {
            var response = await PostAsync<CreateImmediateBasketResponse>($"{ApiRoot}/BasketApi/CreateImmediatePaymentBasket", request);
            if(response.ResponseContent.ResponseCode != "00000")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<BasketSummaryResponse>> GetBasketSummary(BasketSummaryRequest request)
            => await GetAsync<BasketSummaryResponse>($"{ApiRoot}/BasketApi/Summary{request.ToQueryString()}");

        public async Task<HttpResponse<FullBasketSummaryResponse>> GetFullBasketSummary(BasketSummaryRequest request)
            => await GetAsync<FullBasketSummaryResponse>($"{ApiRoot}/BasketApi/FullSummary{request.ToQueryString()}");

        public async Task<HttpResponse<CatalogueItemListResponse>> GetCatalogueItemsAsync(CatalogueItemListRequest request)
            => await GetAsync<CatalogueItemListResponse>($"{ApiRoot}/CatalogueApi/GetCatalogueItemList{request.ToQueryString()}");

        public async Task<HttpResponse<BasketSecurityDetailsResponse>> GetBasketSecurityDetails(BasketSecurityDetailsRequest request)
            => await PostAsync<BasketSecurityDetailsResponse>($"{ApiRoot}/BasketApi/RetrieveBasketSecurityDetails", request);
    }
}