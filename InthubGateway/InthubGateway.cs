using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.AspNetCore.Gateways.InthubGateway
{
    public class InthubGateway : Gateway, IInthubGateway
    {
        private const string HttpClientName = "inthubGateway";

        public InthubGateway(HttpClient client) : base(client)
        {
        }

        public async Task<HttpResponseMessage> UnmatchFosteringCase(string reference)
        {
            return await PostAsync("api/v2/fostering/unmatch", reference);
        }
    }
}
