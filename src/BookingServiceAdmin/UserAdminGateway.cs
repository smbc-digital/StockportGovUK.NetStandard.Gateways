using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string UserEndpoint = "api/v1/User";

        public async Task<HttpResponseMessage> Get(Guid id) =>
            await GetAsync($"{UserEndpoint}/{id}");

        public async Task<HttpResponseMessage> GetByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");

        public async Task<HttpResponseMessage> GetByUsernameFuzzy(string username) =>
            await GetAsync($"{UserEndpoint}/fuzzy/{username}");
    }
}
