using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Inthub
{
    public class InthubGateway : Gateway, IInthubGateway
    {
        public InthubGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> UnmatchFosteringCase(string reference)
            => await PostAsync("api/v2/fostering/unmatch", reference);
    }
}
