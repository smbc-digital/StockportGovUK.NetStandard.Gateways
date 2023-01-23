using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string ContextEndpoint = "api/v1/Context";
        private const string HomeEndpoint = "api/v1/Home";
        private const string ResourceEndpoint = "api/v1/Resource";
        private const string SuspensionEndpoint = "api/v1/Suspension";
        private const string UserEndpoint = "api/v1/User";

        public BookingServiceAdminGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetContexts() =>
            await GetAsync($"{ContextEndpoint}");

        public async Task<HttpResponseMessage> GetContext(Guid contextId) =>
            await GetAsync($"{ContextEndpoint}/{contextId}");

        public async Task<HttpResponseMessage> GetVersionNumber() =>
            await GetAsync($"{HomeEndpoint}/version-number");

        public async Task<HttpResponseMessage> GetByUsername(string username) =>
            await GetAsync($"{UserEndpoint}/name/{username}");

        public async Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request) =>
            await GetAsync($"{SuspensionEndpoint}/active/day-count/{GetByDateQueryString(request)}");

        public async Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(GetByDateRequest request) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/active/day-count/{GetByDateQueryString(request)}");

        private string GetByDateQueryString(GetByDateRequest request) =>
            $"?{nameof(request.Id)}={request.Id}&{nameof(request.Date)}={request.Date:s}";
    }
}
