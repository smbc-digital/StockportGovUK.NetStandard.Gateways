using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async Task<HttpResponseMessage> GetActiveSuspensionCountForContext(Guid contextId, DateTime date) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}/active/{date}");

        public async Task<HttpResponseMessage> GetResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureResourceModifiersForContext(Guid contextId) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveResourceModifierCountForContext(Guid contextId, DateTime date) =>
            await GetAsync($"{ResourceEndpoint}/resource-modifiers/{contextId}/active/{date}");
    }
}
