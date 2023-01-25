using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Context
{
    public class BookingServiceAdminContextGateway : Gateway, IBookingServiceAdminContextGateway
    {
        private const string ContextEndpoint = "api/v1/Context";

        public BookingServiceAdminContextGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetContexts() =>
            await GetAsync($"{ContextEndpoint}");

        public async Task<HttpResponseMessage> GetContext(Guid contextId) =>
            await GetAsync($"{ContextEndpoint}/{contextId}");
    }
}
