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
        private const string BookingEndpoint = "api/v1/Booking";

        public async Task<HttpResponseMessage> GetDayBookingCountForContext(GetByDateRequest request) =>
            await GetAsync($"{BookingEndpoint}/day-count/context/{GetByDateQueryString(request)}");

        public async Task<HttpResponse<IEnumerable<Booking>>> GetNewAndConfirmedBookings(Guid contextId) =>
            await GetAsync<IEnumerable<Booking>>($"{BookingEndpoint}/new-and-confirmed-bookings/{contextId}");

        public async Task<HttpResponse<Booking>> GetBooking(Guid bookingId) =>
            await GetAsync<Booking>($"{BookingEndpoint}/{bookingId}");
    }
}
