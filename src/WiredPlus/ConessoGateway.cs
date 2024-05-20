using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public class ConessoGateway : Gateway, IGateway, IConessoGateway
    {
        private const string ContactEndpoint = "/v2/contacts";
        private const string ListEndpoint = "/v2/lists";

        public ConessoGateway (HttpClient httpClient) : base(httpClient) {  }

        public async Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request)
        {
            return await PostAsync<ContactResponse>(ContactEndpoint, request, true);
        }

        public async Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request)
        {
            if (request.Id.Equals(default))
                throw new HttpRequestException();

            return await PutAsync<ContactResponse>(ContactEndpoint + $"/{request.Id}", request, true);
        }

        public async Task<HttpResponse<ListResponse>> GetListById(int listId)
        {
            return await GetAsync<ListResponse>(ListEndpoint + $"/{listId}");
        }

        public async Task<HttpResponse<List<ListResponse>>> GetLists()
        {
            return await GetAsync<List<ListResponse>>(ListEndpoint + "?showAll=true");
        }

        public async Task<HttpResponse<ContactsResponse>> GetContactByEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new HttpRequestException();

            string url = ContactEndpoint + $"?filter[0][field]=email&filter[0][operator]=equals&filter[0][value]={emailAddress}";

            return await GetAsync<ContactsResponse>(url);
        }

        public async Task<HttpResponse<ContactResponse>> GetContactById(int contactId)
        {
            return await GetAsync<ContactResponse>(ContactEndpoint + $"/{contactId}");
        }
    }
}
