using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public class ConessoGateway : Gateway, IGateway, IConessoGateway
    {
        // Base URL :  https://api.wiredplus.com/
        // Usage Auth Token can be added in the gateway setup as per normal BUT needs to be a BASE64 encoded string of - https://www.base64encode.org/
        // {API_KEY_NAME}:{API_KEY}

        private const string ContactEndpoint = "/v2/contacts";
        private const string ListEndpoint = "/v2/lists";

        public ConessoGateway (HttpClient httpClient) : base(httpClient) {  }

        public async Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request)
        {
            if (!request.ContactListIds.Any() && !request.ContactListId.Equals(default))
                request.ContactListIds.Append(request.ContactListId);
            return await PostAsync<ContactResponse>(ContactEndpoint, request, true);
        }

        public async Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request)
        {
            if (request.Id.Equals(default))
                throw new HttpRequestException();

            if (!request.ContactListIds.Any() && !request.ContactListId.Equals(default))
                request.ContactListIds.Append(request.ContactListId);

            return await PutAsync<ContactResponse>(ContactEndpoint + $"/{request.Id}", request, true);
        }

        public async Task<HttpResponse<List>> GetListById(int listId)
        {
            return await GetAsync<List>(ListEndpoint + $"/{listId}");
        }

        public async Task<HttpResponse<ListResponse>> GetLists()
        {
            return await GetAsync<ListResponse>(ListEndpoint);
        }

        public async Task<HttpResponse<ContactResponse>> GetContactByEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new HttpRequestException();

            string url = ContactEndpoint + $"?filter[0][field]=email&filter[0][operator]=equals&filter[0][value]={emailAddress}";

            return await GetAsync<ContactResponse>(url);
        }
    }
}
