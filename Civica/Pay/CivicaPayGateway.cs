using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Civica.Pay.Request;
using StockportGovUK.NetStandard.Models.Civica.Pay.Response;

namespace StockportGovUK.NetStandard.Gateways.Civica.Pay
{
    public class CivicaPayGateway : Gateway, ICivicaPayGateway
    {

        public const string PAYMENT_URL = "{0}/estore/default/Remote/Fetch?basketreference={1}&baskettoken={2}&callingapptxnreference={3}&backsitename=Stockport%20Homepage&backurl=https://www.stockport.gov.uk";            

        public CivicaPayGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public string EStoreRoot { 
            get
            {
                return $"{base._client.BaseAddress}StockportEstore";
            }
        }

        public string EStoreTestRoot
        {
            get
            {
                return $"{base._client.BaseAddress}StockportEstoreTest";
            }
        }

        public string ApiRoot {
            get
            {
                return "StockportEstore/TransportableBasket/api";
            }
        }

        public string GetPaymentUrl(string basketReference, string basketToken, string reference)
        {
            return string.Format(PAYMENT_URL , EStoreRoot, basketReference, basketToken, reference);            
        }

        public string GetTestPaymentUrl(string basketReference, string basketToken, string reference)
        {
            return string.Format(PAYMENT_URL, EStoreTestRoot, basketReference, basketToken, reference);
        }

        public async Task<HttpResponse<CreateBasketResponse>> CreateBasketAsync(CreateBasketRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/Create";
            var response = await PostAsync<CreateBasketResponse>(url, request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<AddItemResponse>> AddItemAsync(AddItemRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/AddItem";
            var response = await PostAsync<AddItemResponse>(url, request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;    
        }

        public async Task<HttpResponse<RemoveItemResponse>> RemoveItemAsync(RemoveItemRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/RemoveItem";
            var response = await PostAsync<RemoveItemResponse>(url, request);
            if(response.ResponseContent.ResponseCode == "99999")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;    
        }

        public async Task<HttpResponse<CreateImmediateBasketResponse>> CreateImmediateBasketAsync(CreateImmediateBasketRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/CreateImmediatePaymentBasket";
            var response = await PostAsync<CreateImmediateBasketResponse>(url, request);
            if(response.ResponseContent.ResponseCode != "00000")
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<BasketSummaryResponse>> GetBasketSummary(BasketSummaryRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/Summary{request.ToQueryString()}";
            var response = await GetAsync<BasketSummaryResponse>(url);
            return response;
        }

        public async Task<HttpResponse<FullBasketSummaryResponse>> GetFullBasketSummary(BasketSummaryRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/FullSummary{request.ToQueryString()}";
            var response = await GetAsync<FullBasketSummaryResponse>(url);
            return response;
        }

        public async Task<HttpResponse<CatalogueItemListResponse>> GetCatalogueItemsAsync(CatalogueItemListRequest request)
        {
            var url = $"{ApiRoot}/CatalogueApi/GetCatalogueItemList{request.ToQueryString()}";
            var response = await GetAsync<CatalogueItemListResponse>(url);
            return response;
        }

        public async Task<HttpResponse<BasketSecurityDetailsResponse>> GetBasketSecurityDetails(BasketSecurityDetailsRequest request)
        {
            var url = $"{ApiRoot}/BasketApi/RetrieveBasketSecurityDetails";
            var response = await PostAsync<BasketSecurityDetailsResponse>(url, request);
            return response;
        }
    }
}