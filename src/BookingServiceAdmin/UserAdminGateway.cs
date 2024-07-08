using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string UserEndpoint = "api/v1/User";

        public async Task<HttpResponseMessage> GetUserById(Guid id) =>
            await GetAsync($"{UserEndpoint}/{id}");

        public async Task<HttpResponseMessage> GetUserByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");

        public async Task<HttpResponseMessage> GetUsersByUsernameFuzzy(string username) =>
            await GetAsync($"{UserEndpoint}/fuzzy/{username}");
    }
}
