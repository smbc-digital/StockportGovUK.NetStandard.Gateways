using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ContextEndpoint = "api/v1/Context";

        public async Task<HttpResponseMessage> GetContexts() =>
            await GetAsync($"{ContextEndpoint}");

        public async Task<HttpResponseMessage> GetContext(Guid contextId) =>
            await GetAsync($"{ContextEndpoint}/{contextId}");
    }
}
