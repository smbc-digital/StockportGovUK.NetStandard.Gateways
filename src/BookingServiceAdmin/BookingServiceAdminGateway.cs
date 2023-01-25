using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string HomeEndpoint = "api/v1/Home";

        public BookingServiceAdminGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetVersionNumber() =>
            await GetAsync($"{HomeEndpoint}/version-number");
    }
}
