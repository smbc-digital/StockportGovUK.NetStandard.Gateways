using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string SuspensionEndpoint = "api/v1/Suspension";

        public async Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request) =>
            await GetAsync($"{SuspensionEndpoint}/active/day-count/{GetByDateQueryString(request)}");

        public async Task<HttpResponseMessage> UpdateSuspension(SuspensionRequest request) =>
            await PatchAsync($"{SuspensionEndpoint}/edit", request);

        public async Task<HttpResponseMessage> AddSuspension(SuspensionRequest request) =>
            await PostAsync($"{SuspensionEndpoint}", request);
    }
}
