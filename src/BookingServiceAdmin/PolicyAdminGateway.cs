using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string PolicyEndpoint = "api/v1/Policy";

    public async Task<HttpResponse<IEnumerable<Policy>>> GetPolicies(Guid contextId) =>
        await GetAsync<IEnumerable<Policy>>($"{PolicyEndpoint}/context/{contextId}");

    public async Task<HttpResponse<Policy>> GetPolicy(Guid policyId) =>
        await GetAsync<Policy>($"{PolicyEndpoint}/{policyId}");

    public async Task<HttpResponse<Policy>> AddPolicy(PolicyRequest request) =>
        await PostAsync<Policy>(PolicyEndpoint, request);
}