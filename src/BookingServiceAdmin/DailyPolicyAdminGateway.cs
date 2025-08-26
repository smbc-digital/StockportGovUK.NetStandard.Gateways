using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin;

public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
{
    private const string DailyPolicyEndpoint = "api/v1/DailyPolicy";

    public async Task<HttpResponse<IEnumerable<DailyPolicy>>> GetDailyPolicies(Guid contextId) =>
        await GetAsync<IEnumerable<DailyPolicy>>($"{DailyPolicyEndpoint}/context/{contextId}");

    public async Task<HttpResponse<DailyPolicy>> GetDailyPolicy(Guid policyId) =>
        await GetAsync<DailyPolicy>($"{DailyPolicyEndpoint}/{policyId}");

    public async Task<HttpResponse<DailyPolicy>> AddDailyPolicy(DailyPolicyRequest request) =>
        await PostAsync<DailyPolicy>(DailyPolicyEndpoint, request);

    public async Task<HttpResponse<DailyPolicy>> UpdateDailyPolicy(DailyPolicyRequest request) =>
        await PatchAsync<DailyPolicy>(DailyPolicyEndpoint, request);

    public async Task<HttpResponseMessage> DeleteDailyPolicy(Guid dailyPolicyId) =>
        await DeleteAsync($"{DailyPolicyEndpoint}/{dailyPolicyId}");
}