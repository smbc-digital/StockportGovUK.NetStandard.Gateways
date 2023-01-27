using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ResourceEndpoint = "api/v1/Resource";

        public async Task<HttpResponse<List<ResourceModifier>>> GetResourceModifiersForContext(Guid contextId) =>
            await GetAsync<List<ResourceModifier>>($"{ResourceEndpoint}/resource-modifiers/{contextId}");

        public async Task<HttpResponse<List<ResourceModifier>>> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
            await GetAsync<List<ResourceModifier>>($"{ResourceEndpoint}/resource-modifiers/{contextId}/active");

        public async Task<HttpResponse<int>> GetActiveResourceModifierCountForContext(GetByDateRequest request) =>
            await GetAsync<int>($"{ResourceEndpoint}/resource-modifiers/active/day-count/{GetByDateQueryString(request)}");
    }
}
