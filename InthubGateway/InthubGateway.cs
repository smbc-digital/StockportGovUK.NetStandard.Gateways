using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.InthubGateway
{
    public class InthubGateway : Gateway, IInthubGateway
    {
        private const string HttpClientName = "inthubGateway";

        public InthubGateway(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<HttpResponseMessage> UnmatchFosteringCase(string reference)
        {
            return await PostAsync(HttpClientName, "api/v2/fostering/unmatch", reference);
        }
    }
}
