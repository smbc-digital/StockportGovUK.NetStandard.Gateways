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
        private const string ContextEndpoint = "api/v1/Context";

        public async Task<HttpResponse<IEnumerable<BasicContext>>> GetActiveContexts() =>
            await GetAsync<IEnumerable<BasicContext>>($"{ContextEndpoint}");

        public async Task<HttpResponse<IEnumerable<BasicContext>>> GetContexts(bool showDisabled) =>
            await GetAsync<IEnumerable<BasicContext>>($"{ContextEndpoint}/all/{showDisabled}");

        public async Task<HttpResponse<Context>> GetContext(Guid contextId) =>
            await GetAsync<Context>($"{ContextEndpoint}/{contextId}");

        public async Task<HttpResponse<Context>> UpdateContext(ContextRequest request) =>
            await PatchAsync<Context>(ContextEndpoint, request);

        public async Task<HttpResponse<Context>> AddContext(ContextRequest request) =>
            await PostAsync<Context>(ContextEndpoint, request);

        public async Task<HttpResponseMessage> SetContextAvailability(ContextAvailabilityRequest request) =>
            await PatchAsync($"{ContextEndpoint}/availability", request);
    }
}
