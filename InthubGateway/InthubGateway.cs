using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockportGovUK.AspNetCore.Gateways.InthubGateway
{
    public class InthubGateway : Gateway, IInthubGateway
    {
        public InthubGateway(HttpClient httpClient, ILogger<Gateway> logger) : base(httpClient, logger)
        {
        }

        public async Task<HttpResponseMessage> UnmatchFosteringCase(string reference)
        {
            return await PostAsync("api/v2/fostering/unmatch", reference);
        }
    }
}
