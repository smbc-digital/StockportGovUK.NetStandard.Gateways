using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ContextEndpoint = "api/v1/Context";
        private const string HomeEndpoint = "api/v1/Home";
        private const string UserEndpoint = "api/v1/User";

        public BookingServiceAdminGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetContexts() =>
            await GetAsync($"{ContextEndpoint}");

        public async Task<HttpResponseMessage> GetVersionNumber() =>
            await GetAsync($"{HomeEndpoint}/version-number");

        public async Task<HttpResponseMessage> GetByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");
    }
}
