using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ResourceEndpoint = "api/v1/Resource";

        public async Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/active/day-count/{GetByDateQueryString(request)}");
    }
}
