using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Resource
{
    public class BookingServiceAdminResourceGateway : Gateway, IBookingServiceAdminResourceGateway
    {
        private const string ResourceEndpoint = "api/v1/Resource";

        public BookingServiceAdminResourceGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/active/day-count/{QueryStringGenerator.GetByDateQueryString(request)}");
    }
}
