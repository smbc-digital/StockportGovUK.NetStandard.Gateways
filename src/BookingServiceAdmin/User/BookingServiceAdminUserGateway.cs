using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.User
{
    public class BookingServiceAdminUserGateway : Gateway, IBookingServiceAdminUserGateway
    {
        private const string UserEndpoint = "api/v1/User";

        public BookingServiceAdminUserGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");
    }
}
