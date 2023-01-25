using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin.Suspension
{
    public class BookingServiceAdminSuspensionGateway : Gateway, IBookingServiceAdminSuspensionGateway
    {
        private const string SuspensionEndpoint = "api/v1/Suspension";

        public BookingServiceAdminSuspensionGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<HttpResponseMessage> GetSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}");

        public async Task<HttpResponseMessage> GetActiveAndFutureSuspensionsForContext(Guid contextId) =>
            await GetAsync($"{SuspensionEndpoint}/{contextId}/active");

        public async Task<HttpResponseMessage> GetActiveSuspensionCountForContext(GetByDateRequest request) =>
            await GetAsync($"{SuspensionEndpoint}/active/day-count/{QueryStringGenerator.GetByDateQueryString(request)}");
    }
}
