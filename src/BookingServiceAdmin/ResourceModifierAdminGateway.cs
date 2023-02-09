using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string ResourceModifierEndpoint = "api/v1/ResourceModifier";

    public async Task<HttpResponse<IEnumerable<ResourceModifier>>> GetResourceModifiersForContext(Guid contextId) =>
        await GetAsync<IEnumerable<ResourceModifier>>($"{ResourceModifierEndpoint}/context/{contextId}");

    public async Task<HttpResponse<IEnumerable<ResourceModifier>>> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
        await GetAsync<IEnumerable<ResourceModifier>>($"{ResourceModifierEndpoint}/context/{contextId}/active");

    public async Task<HttpResponse<int>> GetActiveResourceModifierCountForContext(GetByDateRequest request) =>
        await GetAsync<int>($"{ResourceModifierEndpoint}/context/active/day-count/{GetByDateQueryString(request)}");
}