using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.Booking.Request;

namespace StockportGovUK.NetStandard.Gateways.BookingServiceAdmin
{
    public partial class BookingServiceAdminGateway : Gateway, IBookingServiceAdminGateway
    {
        private const string BookingEndpoint = "api/v1/Booking";

        public async Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request) =>
            await GetAsync($"{BookingEndpoint}/day-count/context/{GetByDateQueryString(request)}");

        public async Task<HttpResponseMessage> GetNewAndConfirmedBookings(Guid contextId) =>
            await GetAsync($"{BookingEndpoint}/new-and-confirmed-bookings/{contextId}");

        public async Task<HttpResponseMessage> GetBooking(Guid contextId) =>
            await GetAsync($"{BookingEndpoint}/{contextId}");
    }
}
