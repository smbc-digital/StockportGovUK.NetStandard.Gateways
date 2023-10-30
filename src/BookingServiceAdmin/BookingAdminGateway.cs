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

        public async Task<HttpResponse<int>> GetDayBookingCountForContext(GetByDateRequest request) =>
            await GetAsync<int>($"{BookingEndpoint}/day-count/context/{GetByDateQueryString(request)}");

        public async Task<HttpResponse<IEnumerable<Booking>>> GetDayBookingsForContext(GetByDateRequest request) =>
            await GetAsync<IEnumerable<Booking>>($"{BookingEndpoint}/day-list/context/{GetByDateQueryString(request)}");

        public async Task<HttpResponse<IEnumerable<Booking>>> GetNewAndConfirmedBookings(Guid contextId) =>
            await GetAsync<IEnumerable<Booking>>($"{BookingEndpoint}/new-and-confirmed-bookings/{contextId}");

        public async Task<HttpResponse<Booking>> GetBooking(Guid bookingId) =>
            await GetAsync<Booking>($"{BookingEndpoint}/{bookingId}");

        public async Task<HttpResponse<IEnumerable<Booking>>> GetRelatedBookings(Guid groupId) =>
            await GetAsync<IEnumerable<Booking>>($"{BookingEndpoint}/related/{groupId}");

        public async Task<HttpResponse<Booking>> CancelBooking(CancelBookingRequest request) =>
            await PatchAsync<Booking>($"{BookingEndpoint}/cancel", request);

        public async Task<HttpResponse<IEnumerable<Note>>> AddNote(AddNoteRequest request) =>
            await PostAsync<IEnumerable<Note>>($"{BookingEndpoint}/note", request);

        public async Task<HttpResponse<IEnumerable<Status>>> GetStatuses() =>
           await GetAsync<IEnumerable<Status>>($"{BookingEndpoint}/statuses");

        public async Task<HttpResponse<Booking>> UpdateStatus(UpdateBookingStatusRequest request) =>
           await PatchAsync<Booking>($"{BookingEndpoint}/update-status", request);

        public async Task<HttpResponseMessage> UpdateCustomerForBooking(UpdateCustomerForBookingRequest request) =>
            await PatchAsync($"{BookingEndpoint}/update-customer", request);
    }
}
