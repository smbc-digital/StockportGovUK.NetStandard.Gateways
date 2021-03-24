using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Response;
using StockportGovUK.NetStandard.Models.Booking.Request;
using StockportGovUK.NetStandard.Models.Booking.Response;

namespace StockportGovUK.NetStandard.Gateways.BookingService
{
    public interface IBookingServiceGateway
    {
        Task<HttpResponse<List<AvailabilityDayResponse>>> GetAvailability(AvailabilityRequest model);

        Task<HttpResponse<AvailabilityDayResponse>> NextAvailability(AvailabilityRequest model);

        Task<HttpResponse<Guid>> Reserve(BookingRequest model);

        Task<HttpResponseMessage> Confirmation(ConfirmationRequest model);
        Task<HttpResponseMessage> Cancel(string id);

        Task<HttpResponse<string>> GetLocation(LocationRequest model);
    }
}