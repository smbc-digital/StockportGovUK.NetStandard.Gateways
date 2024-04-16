using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Conesso;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.WiredPlus
{
    public class ConessoGateway : Gateway, IConessoGateway
    {
        // Base URL :  https://api.wiredplus.com/
        // Usage Auth Token can be added in the gateway setup as per normal BUT needs to be a BASE64 encoded string of - https://www.base64encode.org/
        // {API_KEY_NAME}:{API_KEY}

        private const string ContactEndpoint = "/v2/contacts";
        private const string ListEndpoint = "/v2/lists";

        public ConessoGateway (HttpClient httpClient) : base(httpClient) {  }

        public async Task<HttpResponse<ContactResponse>> CreateContact(ContactRequest request)
        {
            var content = new MultipartFormDataContent();

            content.AddIfNotNull(request.Email, "email");
            content.AddIfNotNull(request.FirstName, "firstName");
            content.AddIfNotNull(request.LastName, "lastName");
            content.AddIfNotNull(request.PhoneNumber, "phoneNumber");
            content.AddIfNotNull(request.Company, "company");
            content.AddIfNotNull(request.JobTitle, "jobTitle");
            content.AddIfNotNull(request.Address, "address");
            content.AddIfNotNull(request.Address2, "address2");
            content.AddIfNotNull(request.City, "city");
            content.AddIfNotNull(request.County, "county");
            content.AddIfNotNull(request.Postcode, "postcode");
            content.AddIfNotNull(request.CountryCode, "countryCode");
            content.AddIfNotNull(request.Country, "country");
            content.AddIfNotNull(request.Website, "website");
            content.AddIfNotNull(request.Gender, "gender");
            content.AddIfNotNull(request.Tags, "tags");
            content.AddIfNotNull(request.OptIn, "optIn");
            content.AddIfNotNull(request.ContactListId.ToString(), "listIds");

            request.CustomValues.ForEach(_ => content.Add(new StringContent(_.Value), _.Key));

            return await PostAsync<ContactResponse>(ContactEndpoint, content, false);
        }

        public async Task<HttpResponse<ContactResponse>> UpdateContact(ContactRequest request)
        {
            if (request.Id == null)
                throw new HttpRequestException();

            return await PutAsync<ContactResponse>(ContactEndpoint + $"/{request.Id}", new MultipartFormDataContent(), false);
        }

        public async Task<HttpResponse<ListResponse>> GetListById(int listId)
        {
            return await GetAsync<ListResponse>(ListEndpoint + $"/{listId}");
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
