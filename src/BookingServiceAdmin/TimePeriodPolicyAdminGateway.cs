using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;
using StockportGovUK.NetStandard.Gateways.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string TimePeriodPolicyEndpoint = "api/v1/TimePeriodPolicy";

        public async Task<HttpResponse<IEnumerable<TimePeriodPolicy>>> GetTimePeriodPolicies(Guid contextId) =>
            await GetAsync<IEnumerable<TimePeriodPolicy>>($"{TimePeriodPolicyEndpoint}/context/{contextId}");

        public async Task<HttpResponse<TimePeriodPolicy>> GetTimePeriodPolicy(Guid policyId) =>
            await GetAsync<TimePeriodPolicy>($"{TimePeriodPolicyEndpoint}/{policyId}");

        public async Task<HttpResponse<TimePeriodPolicy>> AddTimePeriodPolicy(TimePeriodPolicyRequest request) =>
            await PostAsync<TimePeriodPolicy>(TimePeriodPolicyEndpoint, request);

        public async Task<HttpResponse<TimePeriodPolicy>> UpdateTimePeriodPolicy(TimePeriodPolicyRequest request) =>
            await PatchAsync<TimePeriodPolicy>(TimePeriodPolicyEndpoint, request);

        public async Task<HttpResponseMessage> DeleteTimePeriodPolicy(Guid timePeriodPolicyId) =>
            await DeleteAsync($"{TimePeriodPolicyEndpoint}/{timePeriodPolicyId}");
    }
}
